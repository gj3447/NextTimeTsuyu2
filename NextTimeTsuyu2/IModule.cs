using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public interface IModule
    {
        public NextTimeTsuyu2.Task h_get_task(MemoryCluster memories , Setting setting);
        public Action h_work(NextTimeTsuyu2.Task task,MemoryCluster memories, Setting setting);
        public IModule.STATE h_state(MemoryCluster memories , Setting setting);
        public enum STATE
        {
            WORK,
            STOP,
            END
        }
    }
}
