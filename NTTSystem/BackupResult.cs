using NextTimeTsuyu2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTSystem
{
    public class BackupResult
    {
        //Backup
        public long _total_byte_size { get; init; }
        public DateTime _start_time { get; init; }
        public DateTime _end_time { get; init; }
        public string _mode { get; init; }
        
        public string _read_path { get; init; }
        public string _write_path { get; init; }

        //Setting
        private int _chunk_size { get; init; }
        private int _worker_count { get; init; }
        private long _memory_size { get; init; }
        private string _load_balancer_type{ get; init; }

        public BackupResult(NextTimeTsuyu2.Backup backup)
        {
            _total_byte_size = backup.get_memory_cluster.get_total_byte_size;
            _start_time = backup.get_start_time;
            _end_time = backup.get_end_time;
            _mode = Enum.GetName(typeof(NextTimeTsuyu2.Backup.MODE), backup.get_mode);

            _read_path = backup.get_memory_cluster.get_read_path;
            _write_path = backup.get_memory_cluster.get_write_path;

            _chunk_size = backup.get_setting.get_chunk_size;
            _worker_count = backup.get_setting.get_worker_count; 
            _memory_size = backup.get_setting.get_memory_size;
            _load_balancer_type = Enum.GetName(typeof(NextTimeTsuyu2.LoadBalancer.TYPE), backup.get_setting.get_load_balancer_type);
        }
    }
}
