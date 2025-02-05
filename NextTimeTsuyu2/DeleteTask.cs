using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class DeleteTask : Task
    {
        public DeleteTask.STATE _state;
        public enum STATE
        {
            READ_FILE,
            READ_DIRECTORY,
            WRITE_FILE,
            WRITE_DIRECTORY,
        }
        public void h_delete(MemoryCluster memories)
        {
        }
        public void h_delete_read_directory_dic(MemoryCluster memories)
        {

        }
        public void h_delete_write_directory_dic(MemoryCluster memories)
        {

        }
        public void h_delete_read_file_dic(MemoryCluster memories)
        {

        }
        public void h_delete_write_file_dic(MemoryCluster memories)
        {

        }
    }
}
