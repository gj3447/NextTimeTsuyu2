using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class DeleteReadTask : NextTimeTsuyu2.Task
    {
        bool _file;
        bool _directory;
        public DeleteReadTask(string path,bool file, bool directory)
        {
            _file = file;
            _directory = directory;
            _path = path;
        }
        public void h_read_delete(MemoryCluster memories)
        {
            if (_file)
            {
                h_read_file_delete(memories);
                return;
            }
            if (_directory)
            {
                return;
            }
            throw new Exception("");
        }
        public void h_read_file_delete(MemoryCluster memories)
        {

        }
        public void h_read_file_delete(MemoryCluster memories)
        {

        }
    }
}