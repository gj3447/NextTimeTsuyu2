using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTSystem
{
    public class Copy
    {
        public string _from_path { get; set; }
        public string _to_path { get; set; }
        public object _lock { get; set; }
        public BackupResult _result { get; set; }
        public NextTimeTsuyu2.Backup _backup;
        private bool _copy_able;

        public Copy()
        {
            _copy_able = true;
        }
        public NextTimeTsuyu2.Backup h_copy(NextTimeTsuyu2.Setting setting)
        {
            if (_from_path == _to_path)
                return null;
            if (!_copy_able)
                return null;
            _copy_able = false;
            _backup = null;
            if (Directory.Exists(_from_path)|| File.Exists(_from_path))
            {
                _backup = NextTimeTsuyu2.Backup.h_backup(_from_path, _to_path, setting);
                Task.Run(() =>
                {
                    _backup.Start();
                    _result = new BackupResult(_backup);
                    _copy_able = true;
                });
                return _backup;
            }
            return null;
        }
    }
}
