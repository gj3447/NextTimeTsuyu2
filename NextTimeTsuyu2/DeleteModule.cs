using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class DeleteModule : IModule
    {
        public Task h_get_task(MemoryCluster memories, Setting setting)
        {
            throw new NotImplementedException();
        }

        public IModule.STATE h_state(MemoryCluster memories, Setting setting)
        {
            throw new NotImplementedException();
        }

        public Action h_work(Task task, MemoryCluster memories, Setting setting)
        {
            throw new NotImplementedException();
        }
    }
}