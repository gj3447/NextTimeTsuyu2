using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class WriteTask : Task
    {
        public static string h_path2temppath(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileName(path);
            return Path.Combine(directory, $".{filename}.tsuyu_temp");
        }
        public int _index { get; set; }
        public byte[] _data { get; set; }
        public void h_file_write(MemoryCluster memories,int chunk_size)
        {
            if (memories == null)
                throw new ArgumentNullException("메모리가 없습니다?");

            string write_path = h_write_path(memories);
            string temp_path = h_path2temppath(write_path);

            memories.h_write_byte_size(_data.Length);


            long offset = (long)chunk_size * (long)_index;
         
            using (FileStream fs = new FileStream(temp_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {      
                fs.Seek(offset, SeekOrigin.Begin);
                fs.Write(_data, 0, _data.Length);
            }
            if (_index == 0)
            {
                memories.get_swap_task_queue.Enqueue(
                    new SwapTask
                    {
                        _path = write_path,
                        _temp_path = temp_path,
                    });
            }
        }
    }
}
