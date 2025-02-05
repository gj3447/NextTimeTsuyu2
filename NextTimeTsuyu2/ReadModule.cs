using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class ReadModule : IModule
    {
        public Task h_get_task(MemoryCluster memories, Setting setting)
        {
            NextTimeTsuyu2.ReadTask task = null;
            if (!memories.get_read_task_queue.TryDequeue(out task))
                throw new Exception("why read queue is null");
            return task;
        }

        public IModule.STATE h_state(MemoryCluster memories, Setting setting)
        {
            if(memories.get_read_task_queue.IsEmpty)
            {
                if(memories.get_search_task_queue.IsEmpty)
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
                return IModule.STATE.WORK;
            }
        }

        public Action h_work(Task task, MemoryCluster memories, Setting setting)
        {
            ReadTask RT = task as ReadTask;
            if (RT == null)
                throw new Exception("readTask is null");
            else
                return () => { 
                    byte[] data = RT.h_file_read(memories, setting.get_chunk_size);
                    memories.get_write_task_queue.Enqueue
                    (
                        new WriteTask
                        {
                            _data = data,
                            _index = RT._index,
                            _path = RT._path,
                        }
                    );
                };
        }
    }
}
