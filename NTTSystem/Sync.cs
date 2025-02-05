
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTSystem
{
    public class Sync
    {
        public static uint _id_counter;
        public uint _id;
        public string _from_path { get; set; }
        public string _to_path { get; set; }


        private DateTime _last_sync_time;
        public BackupResult _result { get; set; }

        private object _lock = new object();

        public Sync(string from_path , string to_path)
        {
            _id = _id_counter++;
            _from_path = from_path;
            _to_path = to_path;

            _last_sync_time = DateTime.MinValue;
        }
        public NextTimeTsuyu2.Backup h_sync_update(NextTimeTsuyu2.Setting setting)
        {
            if (!File.Exists(_from_path))
                return null;
            if (!File.Exists(_to_path))
                return null;
            if (new FileInfo(_to_path).LastWriteTime == _last_sync_time)
                return null;

            NextTimeTsuyu2.Backup backup =
                NextTimeTsuyu2.Backup.h_backup(_from_path, _to_path, setting);
            Task.Run(() => {
                lock (_lock)
                {
                    backup.Start();
                    _result = new BackupResult(backup);
                    _last_sync_time = new FileInfo(_to_path).LastWriteTime;
                }
            });
            return backup;
        }
        public NextTimeTsuyu2.Backup h_sync(NextTimeTsuyu2.Setting setting)
        {
            if (!File.Exists(_from_path))
                return null;
            if (!File.Exists(_to_path))
                return null;

            NextTimeTsuyu2.Backup backup = 
                NextTimeTsuyu2.Backup.h_backup(_from_path, _to_path, setting);

            
            Task.Run(() => {
                lock (_lock)
                {
                    backup.Start();
                    _result = new BackupResult(backup);
                    _last_sync_time = new FileInfo(_to_path).LastWriteTime;
                }
            });
            return backup;
        }
        public void h_swap()
        {
            lock(_lock)
            {
                string temp = _from_path;
                _from_path = _to_path;
                _to_path = temp;
            }
        }
    }
}
