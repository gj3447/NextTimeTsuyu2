using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class DeleteReadModule : IModule
    {
        public Task h_get_task(MemoryCluster memories, Setting setting)
        {
            if (memories.get_read_directory_dic.Count > 0)
            {
                List<string> string_list = new List<string> (memories.get_read_directory_dic.Keys);
                string directory_path = string_list[0];

                DeleteReadTask task = new DeleteReadTask(directory_path,false, true);
                return task;
            } 
            else if (memories.get_read_file_dic.Count > 0)
            {
                List<string> string_list = new List<string>(memories.get_read_file_dic.Keys);
                string file_path = string_list[0];

                DeleteReadTask task = new DeleteReadTask(file_path,true,false);
                return task;
            }
            else
            {
                throw new Exception("why queue is null");
            }
            return null;
        }

        public IModule.STATE h_state(MemoryCluster memories, Setting setting)
        {
            if (memories.get_read_directory_dic.Count > 0 ||
                memories.get_read_file_dic.Count > 0)
            {
                return IModule.STATE.WORK;
            }
            else
            {
                return IModule.STATE.END;
            }
        }

        public Action h_work(Task task, MemoryCluster memories, Setting setting)
        {
            DeleteReadTask drt = task as DeleteReadTask;
            if(drt!= null)
            {
                return () =>
                { };
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
