using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class DeleteWriteTask : NextTimeTsuyu2.Task
    {
        bool _file;
        bool _directory;
        public DeleteWriteTask(string path , bool file, bool directory)
        {
            _file = file;
            _path = path;
            _directory = directory;
        }
        public void h_write_delete(MemoryCluster memories)
        {
            if (_file)
            {
                return;
            }
            if (_directory)
            {
                return;
            }
            throw new Exception("");
        }
    }
}
