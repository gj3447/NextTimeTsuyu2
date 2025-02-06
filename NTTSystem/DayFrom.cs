using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NTTSystem
{
    //폴더만
    public class DayFrom
    {
        public static uint _id_counter;
        public uint _id { get; set; }

        public string _from_path { get; set; }
        public string _to_path { get; set; }
        public List<DayTo> _day_to_list { get; set; }
        public DayTo _day_to_selected { get; set; }

        public bool _mon { get; set; }
        public bool _tue { get; set; }
        public bool _wed { get; set; }
        public bool _thu { get; set; }
        public bool _fri { get; set; }
        public bool _sat { get; set; }
        public bool _sun { get; set; }
        
        public bool _run { get; set; }
        private DateTime _backup_date { get; set; }

        public bool restore_able { get; set; }
        public int last_dayto_count;
        public DayFrom(string from_path,string to_path)
        {
            _id = _id_counter++;
            _from_path = from_path;
            _to_path = to_path;
            _mon = false;
            _tue = false;
            _wed = false;
            _thu = false;
            _fri = false;
            _sat = false;
            _sun = false;

            _run = false;
            _backup_date = DateTime.MinValue;
            _day_to_list = new List<DayTo>();
            restore_able = true;
            last_dayto_count = 0;
        }
        public DayTo h_day_from_update(NextTimeTsuyu2.Setting setting)
        {
            if (_run)
            {
                DayOfWeek today = DateTime.Now.DayOfWeek;
                DateTime todayDate = DateTime.Now.Date;

                bool shouldRun = today switch
                {
                    DayOfWeek.Monday => _mon,
                    DayOfWeek.Tuesday => _tue,
                    DayOfWeek.Wednesday => _wed,
                    DayOfWeek.Thursday => _thu,
                    DayOfWeek.Friday => _fri,
                    DayOfWeek.Saturday => _sat,
                    DayOfWeek.Sunday => _sun,
                    _ => false
                };

                if (shouldRun && _backup_date.Date != todayDate)
                {
                    _backup_date = todayDate;
                    return h_day_to_backup(setting);
                }
            }
            return null;
        }
        public DayTo h_day_to_backup(NextTimeTsuyu2.Setting setting)
        {
            if (!Directory.Exists(_from_path))
                throw new Exception("Day From 오류 _from_path 에 폴더가 없습니다");
            if(!Directory.Exists(_to_path))
                throw new Exception("Day From 오류 _to_path 에 폴더가 없습니다");

            string safeDirName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string write_path = Path.Combine(_to_path, safeDirName);

            NextTimeTsuyu2.Backup backup = NextTimeTsuyu2.Backup.h_backup(_from_path, write_path, setting);
            Task.Run(() =>{ 
                backup.Start();
            });
            return new DayTo(this,write_path,null);
        }
        public DayTo h_day_to_search(int id)
        {
            foreach(DayTo e in _day_to_list)
            {
                if (e._id == id)
                    return e;
            }
            return null;
        }
        public DayTo h_day_to_search(string write_path)
        {
            foreach (DayTo e in _day_to_list)
            {
                if (e._write_path == write_path)
                    return e;
            }
            return null;
        }
    }
}
