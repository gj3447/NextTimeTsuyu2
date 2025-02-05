using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTSystem
{
    public class DayTo
    {
        public static uint _id_counter;
        public uint _id { get; set; }
        public DayFrom _day_from { get; set; }
        public string _write_path { get; set; }
        public BackupResult _result { get; set; }

        public DayTo(DayFrom day_from, string write_path, BackupResult result)
        {
            _id = _id_counter++;
            _day_from = day_from;
            _write_path = write_path;
            _result = result;
        }
    }
}
