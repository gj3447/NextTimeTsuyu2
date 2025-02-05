using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class SearchModule : IModule
    {
        public NextTimeTsuyu2.Task h_get_task(MemoryCluster memories, Setting setting)
        {
            NextTimeTsuyu2.SearchTask task = null;
            if (!memories.get_search_task_queue.TryDequeue(out task))
                throw new Exception("why search queue is null");
            return task;
        }

        public IModule.STATE h_state(MemoryCluster memories, Setting setting)
        {
            if (memories.get_search_task_queue.IsEmpty)
                return IModule.STATE.END;
            else
                return IModule.STATE.WORK;
        }

        public Action h_work(Task task, MemoryCluster memories, Setting setting)
        {
            SearchTask ST = task as SearchTask;
            if (ST == null)
                throw new Exception("Search Module 의 Search Task 형변환 실패");
            else
            {
                if (ST._state == SearchTask.STATE.READ)
                    return () => { ST.h_search_read(memories, setting.get_chunk_size); };
                if (ST._state == SearchTask.STATE.WRITE)
                    return () => { ST.h_search_write(memories, setting.get_chunk_size); };
                return null;
            }
        }
    }
}
