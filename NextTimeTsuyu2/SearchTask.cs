using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class SearchTask : NextTimeTsuyu2.Task
    {
        public SearchTask.STATE _state;
        public void h_search_read(MemoryCluster memories, int chunk_size)
        {
            DirectoryInfo dir = h_read_directory_info(memories);
            foreach (DirectoryInfo e in dir.GetDirectories())
            {
                string dirpath = Path.GetRelativePath(memories.get_read_path, e.FullName);
                memories.get_search_task_queue.Enqueue(
                    new SearchTask
                    {
                        _state = SearchTask.STATE.READ,
                        _path = dirpath
                    });
            }
            foreach (FileInfo e in dir.GetFiles())
            {
                string filepath = Path.GetRelativePath(memories.get_read_path, e.FullName);
                int index = (int)Math.Ceiling(e.Length / (double)chunk_size);
                memories.h_search_byte_size(e.Length);
                for (int i = 0; i < index; i++)
                {
                    memories.get_read_task_queue.Enqueue(
                        new ReadTask
                        {
                            _path = filepath,
                            _index = i
                        });
                }
                if (!memories.get_read_file_dic.TryAdd(filepath, e))
                    throw new Exception("read file dic crash");
            }
            if (!memories.get_read_directory_dic.TryAdd(_path, dir))
                throw new Exception("read directory dic crash");
        }
        public void h_search_write(MemoryCluster memories,int chunk_size)
        {

            DirectoryInfo dir = h_write_directory_info(memories);

            foreach (DirectoryInfo e in dir.GetDirectories())
            {
                string dirpath = Path.GetRelativePath(memories.get_write_path, e.FullName);
                memories.get_search_task_queue.Enqueue(
                    new SearchTask
                    {
                        _state = SearchTask.STATE.WRITE,
                        _path = dirpath
                    });
            }
            foreach (FileInfo e in dir.GetFiles())
            {
                string filepath = Path.GetRelativePath(memories.get_write_path, e.FullName);
                if(!memories.get_write_file_dic.TryAdd(filepath, e))
                    throw new Exception("write file dic crash");
            }
            if (!memories.get_write_directory_dic.TryAdd(_path, dir))
                throw new Exception("write directory dic crash");
        }
        public enum STATE
        {
            READ,
            WRITE,
        }
    }
}