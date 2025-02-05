using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class MemoryCluster
    {

        #region task queue

        //postprocess
        private ConcurrentQueue<SearchTask> _search_task_queue;
        //process
        private ConcurrentQueue<ReadTask> _read_task_queue;
        private ConcurrentQueue<WriteTask> _write_task_queue;
        //stopprocess
        private ConcurrentQueue<SwapTask> _swap_task_queue;

        #endregion
        //dic list

        #region dictionary
        private ConcurrentDictionary<string, FileInfo>      _read_file_dic;
        private ConcurrentDictionary<string, DirectoryInfo> _read_directory_dic;
        private ConcurrentDictionary<string, FileInfo>      _write_file_dic;
        private ConcurrentDictionary<string, DirectoryInfo> _write_directory_dic;

        private ConcurrentDictionary<string, FileInfo>      _create_file_dic;
        private ConcurrentDictionary<string, DirectoryInfo> _create_directory_dic;



        #endregion

        private string _read_path;
        private string _write_path;

        private long _total_byte_size;
        private long _use_byte_size;
        private long _worked_byte_size;

        private object _total_lock = new object();
        private object _use_lock = new object();
        private object _worked_lock = new object();

        public bool get_preprocess_queue_empty
        {
            get
            {
                if (!_search_task_queue.IsEmpty) return false;
                return true;
            }
        }
        public bool get_process_queue_empty
        {
            get
            {
                if (!_read_task_queue.IsEmpty) return false;
                if (!_write_task_queue.IsEmpty) return false;
                return true;
            }
        }
        public bool get_postprocess_queue_empty
        {
            get
            {
                if (!_swap_task_queue.IsEmpty) return false;

                if (!_read_file_dic.IsEmpty) return false;
                if (!_write_file_dic.IsEmpty) return false;
                if (!_read_directory_dic.IsEmpty) return false;
                if (!_write_directory_dic.IsEmpty) return false;
                return true;
            }
        }
        public bool get_stop_queue_empty
        {
            get
            {
                if (!_create_file_dic.IsEmpty) return false;
                if (!_create_directory_dic.IsEmpty) return false;
                return true;
            }
        }
        public bool get_queue_empty
        {
            get
            {
                if (!get_postprocess_queue_empty) return false;
                if (!get_process_queue_empty) return false;
                if (!get_preprocess_queue_empty) return false;
                return true;
            }
        }
        public ConcurrentQueue<SearchTask> get_search_task_queue => this._search_task_queue;
        public ConcurrentQueue<ReadTask> get_read_task_queue => this._read_task_queue;
        public ConcurrentQueue<WriteTask> get_write_task_queue => this._write_task_queue;
        public ConcurrentQueue<SwapTask> get_swap_task_queue => this._swap_task_queue;

        public ConcurrentDictionary<string, FileInfo> get_read_file_dic => this._read_file_dic;
        public ConcurrentDictionary<string, FileInfo> get_write_file_dic => this._write_file_dic;
        
        public ConcurrentDictionary<string, DirectoryInfo> get_read_directory_dic=> this._read_directory_dic;
        public ConcurrentDictionary<string, DirectoryInfo> get_write_directory_dic => this._write_directory_dic;

        public ConcurrentDictionary<string, FileInfo> get_create_file_dic => this._create_file_dic;

        public ConcurrentDictionary<string, DirectoryInfo> get_create_directory_dic => this._create_directory_dic;
        public string get_read_path => this._read_path;
        public string get_write_path => this._write_path;

        public long get_total_byte_size => this._total_byte_size;
        public long get_use_byte_size => this._use_byte_size;
        public long get_worked_byte_size => this._worked_byte_size;

        public void h_search_byte_size(long byte_size)
        {
            lock (_total_lock)
            {
                _total_byte_size += byte_size;
            }
        }
        public void h_read_byte_size(long byte_size)
        {
            lock (_use_lock)
            {
                _use_byte_size += byte_size;
            }
        }
        public void h_write_byte_size(long byte_size)
        {
            lock (_use_lock)
            {
                _use_byte_size -= byte_size;
            }
            lock (_worked_lock)
            {
                _worked_byte_size += byte_size;
            }
        }
        public MemoryCluster(string read_path , string write_path)
        {
            this._search_task_queue = new ConcurrentQueue<SearchTask>();
            this._read_task_queue = new ConcurrentQueue<ReadTask>();
            this._write_task_queue = new ConcurrentQueue<WriteTask>();
            this._swap_task_queue = new ConcurrentQueue<SwapTask>();

            this._read_file_dic = new ConcurrentDictionary<string, FileInfo>();
            this._write_file_dic =new ConcurrentDictionary<string, FileInfo>();
            this._read_directory_dic = new ConcurrentDictionary<string, DirectoryInfo>();
            this._write_directory_dic = new ConcurrentDictionary<string, DirectoryInfo>();

            this._create_file_dic = new ConcurrentDictionary<string, FileInfo>();
            this._create_directory_dic = new ConcurrentDictionary<string, DirectoryInfo>();

            this._read_path = read_path;
            this._write_path = write_path;

            this._total_byte_size = 0;
            this._use_byte_size = 0;
            this._worked_byte_size = 0;
        }
    }
}