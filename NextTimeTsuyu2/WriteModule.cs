using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class WriteModule : IModule
    {
        public Task h_get_task(MemoryCluster memories, Setting setting)
        {

            NextTimeTsuyu2.WriteTask task = null;
            if (!memories.get_write_task_queue.TryDequeue(out task))
                throw new Exception("why search queue is null");
            return task;
        }

        public IModule.STATE h_state(MemoryCluster memories, Setting setting)
        {
            if(memories.get_write_task_queue.IsEmpty)
            {
                if(memories.get_read_task_queue.IsEmpty && memories.get_search_task_queue.IsEmpty)
                {
                    return IModule.STATE.END;
                }
                else
                {
                    return IModule.STATE.STOP;
                }
            }
            else
            {
                if(memories.get_search_task_queue.IsEmpty)
                {
                    return IModule.STATE.WORK;
                }
                else
                {
                    return IModule.STATE.STOP;
                }
            }
        }

        public Action h_work(Task task, MemoryCluster memories, Setting setting)
        {
            WriteTask WT = task as WriteTask;
            if (WT == null)
                throw new Exception("Write Module 의 Write Task 형변환 실패");
            else
            {
                return () =>
                {
                    WT.h_file_write(memories, setting.get_chunk_size);
                };
            }
        }
    }
}
