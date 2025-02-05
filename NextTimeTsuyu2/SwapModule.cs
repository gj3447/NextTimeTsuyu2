using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class SwapModule : IModule
    {
        public Task h_get_task(MemoryCluster memories, Setting setting)
        {
            SwapTask ST = null;
            if (!memories.get_swap_task_queue.TryDequeue(out ST))
                throw new Exception("swap task is empty");
            else
                return ST;
        }

        public IModule.STATE h_state(MemoryCluster memories, Setting setting)
        {
            if(memories.get_preprocess_queue_empty && memories.get_process_queue_empty)
            {
                if(memories.get_swap_task_queue.IsEmpty)
                {
                    return IModule.STATE.END;
                }
                else
                {
                    return IModule.STATE.WORK;
                }
            }
            else
            {
                return IModule.STATE.STOP;
            }
        }

        public Action h_work(Task task, MemoryCluster memories, Setting setting)
        {
            SwapTask ST = task as SwapTask;
            if (ST == null)
                throw new Exception("Swap Module Error task is not swap task");
            else
            {
                return () =>
                {
                    ST.h_swap(memories);
                };
            }
        }
    }
}