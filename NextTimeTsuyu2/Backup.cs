using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class Backup
    {
        private ModuleCluster _module_cluster;
        private MemoryCluster _memory_cluster;
        private Setting _setting;
        private Backup.MODE _mode;
        private Backup.STATE _state;
        private LoadBalancer _loadbalancer;

        private System.Threading.Tasks.Task[] _worker;
        private object[] _worker_lock;

        private DateTime _start_time;
        private DateTime _end_time;

        public MemoryCluster get_memory_cluster => _memory_cluster;
        public ModuleCluster get_module_cluster => _module_cluster;
        public Setting get_setting => _setting;
        public Backup.MODE get_mode => _mode;
        public LoadBalancer get_loadbalancer => _loadbalancer;

        public Backup.STATE get_state => _state;
        public System.Threading.Tasks.Task[] get_worker => _worker;
        public object[] get_worker_lock => _worker_lock;

        public DateTime get_start_time => _start_time;
        public DateTime get_end_time => _end_time;
        
        public static Backup h_backup_start
            (string read_path, string write_path,Setting setting)
        {
            if(File.Exists(read_path))
            {
                Backup backup =h_file_backup(read_path, write_path, setting);
                backup.Start();
                return backup;
            }
            if(Directory.Exists(read_path))
            {
                Backup backup= h_directory_backup(read_path, write_path, setting);
                backup.Start();
                return backup;
            }
            throw new Exception("읽을 경로에 파일이 없습니다.");
        }
        public static async System.Threading.Tasks.Task<Backup> h_backup_start_async
            (string read_path, string write_path, Setting setting)
        {
            if(File.Exists(read_path))
            {
                Backup backup = h_file_backup(read_path, write_path, setting);
                await backup.Start_async();
                return backup;
            }
            if(Directory.Exists(read_path))
            {
                Backup backup = h_file_backup(read_path, write_path, setting);
                await backup.Start_async();
                return backup;
            }
            throw new Exception("읽을 경로에 파일이 없습니다.");
        }
        public static Backup h_backup
            (string read_path, string write_path, Setting setting)
        {
            if (File.Exists(read_path))
                return h_file_backup(read_path, write_path, setting);
            if (Directory.Exists(read_path))
                return h_directory_backup(read_path, write_path, setting);
            throw new Exception("읽을 경로에 파일이 없습니다");
        }
        public static Backup h_file_backup
            (string read_path , string write_path, Setting setting)
        {
            ModuleCluster module_cluster = new ModuleCluster();
            MemoryCluster memory_cluster = new MemoryCluster(read_path, write_path);
            Setting new_setting = new Setting(setting);
            return new Backup(module_cluster, memory_cluster, new_setting, Backup.MODE.FILE_BACKUP);
        }
        public static Backup h_directory_backup
            (string read_path, string write_path, Setting setting)
        {

            ModuleCluster module_cluster = new ModuleCluster();
            MemoryCluster memory_cluster = new MemoryCluster(read_path, write_path);
            Setting new_setting = new Setting(setting);
            return new Backup(module_cluster, memory_cluster, new_setting, Backup.MODE.DIRECTORY_BACKUP);
        }

        public Backup Start()
        {
            _start_time = DateTime.Now;
            _worker = new System.Threading.Tasks.Task[_setting.get_worker_count];
            _worker_lock = new object[_setting.get_worker_count];
            if(_mode == Backup.MODE.FILE_BACKUP)
                FileCopyPreProcess();
            if (_mode == Backup.MODE.DIRECTORY_BACKUP)
                DirectoryCopyPreProcess();

            Work();

            _end_time = DateTime.Now;
            if (_mode == Backup.MODE.FILE_BACKUP)
                Console.WriteLine("파일 복사 끝");
            if (_mode == Backup.MODE.DIRECTORY_BACKUP)
                Console.WriteLine("폴더 복사 끝");
            _state = Backup.STATE.END;

            return this;
        }
        public async System.Threading.Tasks.Task<Backup> Start_async()
        {
            await System.Threading.Tasks.Task.Run(Start);
            return this;
        }
        private void FileCopyPreProcess()
        {
            FileInfo readfile = new FileInfo(_memory_cluster.get_read_path);

            if (!readfile.Exists)
                throw new FileNotFoundException($"읽기 파일이 존재하지 않습니다: {readfile.FullName}");
            int index = (int)Math.Ceiling(readfile.Length / (double)_setting.get_chunk_size);

            for (int i = 0; i < index; i++)
            {
                _memory_cluster.get_read_task_queue.Enqueue(new ReadTask
                {
                    _path = "",
                    _index = i
                });
            }
        }
        private void DirectoryCopyPreProcess()
        {
            if (!Directory.Exists(_memory_cluster.get_read_path))
                throw new DirectoryNotFoundException($"읽을 디렉토리 위치가 존재하지 않습니다");
            if (!Directory.Exists(_memory_cluster.get_write_path))
                Directory.CreateDirectory(_memory_cluster.get_write_path);

            _memory_cluster.get_search_task_queue.Enqueue(
                new SearchTask
                {
                    _path = "",
                    _state = SearchTask.STATE.READ
                });
            _memory_cluster.get_search_task_queue.Enqueue(
                new SearchTask
                {
                    _path = "",
                    _state = SearchTask.STATE.WRITE
                });
        }

        private void Work()
        {
            _state = STATE.PRE_PROCESS;
            Console.WriteLine(_state);
            do
            {
                for (int i = 0; i < _setting.get_worker_count; i++)
                {
                    object mylock = false;
                    _worker_lock[i] = mylock;
                    _worker[i] = new System.Threading.Tasks.Task(() => { WorkRepeat(this, mylock); });
                }
                foreach (var e in _worker)
                {
                    e.Start();
                }
                foreach (var e in _worker)
                {
                    e.Wait();
                }

                //끝날때까지 대기염
                switch (_state)
                {
                    case STATE.PRE_PROCESS:
                        _state = STATE.PROCESS;
                        Console.WriteLine(_state);
                        break;
                    case STATE.PROCESS:
                        _state = STATE.POST_PROCESS;
                        Console.WriteLine(_state);
                        break;
                    case STATE.POST_PROCESS:
                        _state = STATE.STOP;
                        Console.WriteLine(_state);
                        return;
                    case STATE.STOP:
                        _state = STATE.STOP;
                        Console.WriteLine(_state);
                        return;
                }
            } while (_state != STATE.STOP);
        }
        private void WorkRepeat(Backup backup, object this_lock)
        {
            while (true)
            {
                IModule selected_module = null;
                Task pop_task = null;
                Action work = null;
                lock (backup.get_loadbalancer)
                {
                    selected_module = backup.get_loadbalancer.get_module();
                    if (selected_module != null)
                    {
                        pop_task = selected_module.h_get_task(get_memory_cluster, get_setting);
                        if (pop_task != null)
                            work = selected_module.h_work(pop_task, backup.get_memory_cluster, backup.get_setting);
                    }
                }
                if (work != null)
                {
                    this_lock = true;
                    work();
                    this_lock = false;
                }
                else
                {
                    bool any_worker_lock = false;
                    foreach (bool e in _worker_lock)
                    {
                        if (e) any_worker_lock = true;
                    }
                    if (!any_worker_lock)
                    {
                        return;
                    }
                    else
                    {
                        Thread.Sleep(1);
                    }
                }
            }
        }

        public Backup(ModuleCluster module_cluster , MemoryCluster memory_cluster, Setting setting, Backup.MODE mode)
        {
            this._module_cluster = module_cluster;
            this._memory_cluster = memory_cluster;
            this._setting        = setting;
            this._mode           = mode;
            this._loadbalancer = LoadBalancer.h_create_loadbalancer(this, setting.get_load_balancer_type);
            this._state = STATE.PRE_PROCESS;
        }
        public enum MODE
        {
            FILE_BACKUP,
            DIRECTORY_BACKUP,
        }
        public enum STATE
        {
            PRE_PROCESS,
            PROCESS,
            POST_PROCESS,
            STOP,
            END,
        }
    }
}
