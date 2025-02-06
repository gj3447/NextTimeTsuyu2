using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class Setting
    {
        private int    _chunk_size;
        private int _worker_count;
        private long _memory_size;
        private LoadBalancer.TYPE _load_balancer_type;

        public int get_chunk_size 
        { get { return _chunk_size; } }
        public int get_worker_count 
        { get { return _worker_count; }  }
        public long get_memory_size
        { get { return _memory_size; } }
        public LoadBalancer.TYPE get_load_balancer_type
        { get { return _load_balancer_type; } }


        public int set_chunk_size
        { set { _chunk_size = value; } }
        public int set_worker_count
        { set { _worker_count = value; } }
        public long set_memory_size
        { set { _memory_size = value; } }
        public LoadBalancer.TYPE set_load_balancer_type
        { set { _load_balancer_type = value; } }

        public Setting (int chunk_size, int worker_count, long memory_size, LoadBalancer.TYPE load_balancer_type)
        {
            this._chunk_size         = chunk_size;
            this._worker_count       = worker_count;
            this._memory_size        = memory_size;
            this._load_balancer_type = load_balancer_type;
        }
        public Setting (Setting setting)
        {
            this._chunk_size         = setting.get_chunk_size;
            this._worker_count       = setting.get_worker_count;
            this._memory_size        = setting.get_memory_size;
            this._load_balancer_type = setting.get_load_balancer_type;
        }
    }
}
