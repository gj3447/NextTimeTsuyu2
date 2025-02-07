using NextTimeTsuyu2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTSystem
{
    public class SystemSettingFile
    {
        private static int base_chunk_size =   1024;
        private static long base_memory_size = 1024 * 1024;
        private static NextTimeTsuyu2.LoadBalancer.TYPE base_loadbalancer_type = LoadBalancer.TYPE.BASIC;

        public NTTSystem.Copy _copy {get;set;}
        public List<DayFrom> _day_from_list { get; set; }
        public List<Sync> _sync_list { get; set; }
        public NextTimeTsuyu2.Setting _setting {get;set;}
        public DayFrom _day_from_selected { get; set; }
        public Sync _sync_selected { get; set; }

        public SystemSettingFile()
        {
            _copy = new NTTSystem.Copy();
            _day_from_list = new List<DayFrom>();
            _sync_list = new List<Sync>();
            _setting = new Setting(base_chunk_size, Environment.ProcessorCount, base_memory_size, base_loadbalancer_type);
            _day_from_selected = null;
            _sync_selected     = null;
        }

        //무조건 폴더들만
        public DayFrom h_day_from_add(string from_path, string to_path)
        {
            if (!Directory.Exists(from_path))
                return null;
            
            foreach(DayFrom e in _day_from_list)
            {
                if (e._from_path == from_path)
                    return null;
            }
            if(!Directory.Exists(to_path))
                Directory.CreateDirectory(to_path);

            DayFrom df = new DayFrom(from_path, to_path);
            _day_from_list.Add(df);
            return df;
        }

        public void h_day_from_update()
        {
            foreach(DayFrom e in _day_from_list)
            {
                DayTo dt = e.h_day_from_update(_setting);
                e._day_to_list.Add(dt);
            }
        }
        public DayFrom h_day_from_search(int id)
        {
            foreach(DayFrom e in _day_from_list)
            {
                if (e._id == id)
                    return e;
            }
            return null;
        }
        public DayFrom h_day_from_search(string from_path)
        {
            foreach (DayFrom e in _day_from_list)
            {
                if (e._from_path == from_path)
                    return e;
            }
            return null;
        }
        public bool h_sync_update()
        {
            foreach (Sync e in _sync_list)
            {
                if (!e.is_sync_able)
                    return false;
            }
            foreach (Sync e in _sync_list)
            {
                e.h_sync_update(_setting);
            }
            return true;
        }
        public bool h_all_sync()
        {
            foreach (Sync e in _sync_list)
            {
                if (!e.is_sync_able)
                    return false;
            }
            foreach (Sync e in _sync_list)
            {
                var aa = e.h_sync(_setting);
                if (aa == null)
                    return false;
            }
            return true;
        }
        public bool h_all_sync_swap()
        {
            foreach (Sync e in _sync_list)
            {
                if (!e.is_sync_able)
                    return false;
            }
            foreach (Sync e in _sync_list)
            {
                e.h_swap();
            }
            return true;
        }
        public Sync h_sync_add(string from_path, string to_path)
        {
            if (!File.Exists(from_path))
                return null;
            if (Directory.Exists(to_path))
                return null;

            foreach (Sync e in _sync_list)
            {
                if (e._from_path == from_path)
                    return null;
                if (e._to_path == to_path)
                    return null;
            }

            Sync sync = new Sync(from_path, to_path);
            _sync_list.Add(sync);
            return sync;
        }
        public Sync h_sync_search(int id)
        {
            foreach (Sync e in _sync_list)
            {
                if (e._id == id)
                    return e;
            }
            return null;
        }
        public Sync h_sync_search(string from_path)
        {
            foreach(Sync e in _sync_list)
            {
                if (e._from_path == from_path)
                    return e;
            }
            return null;
        }
        public Sync h_sync_search(string from_path, string to_path)
        {
            foreach (Sync e in _sync_list)
            {
                if (e._from_path == from_path&&e._to_path == to_path)
                    return e;
            }
            return null;
        }
        public NextTimeTsuyu2.Backup h_copy()
        {
            NextTimeTsuyu2.Backup result = _copy.h_copy(_setting);
            return result;
        }
    }
}
