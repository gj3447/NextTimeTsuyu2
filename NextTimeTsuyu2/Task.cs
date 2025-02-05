using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class Task
    {
        public string _path { get; init; }

        public string h_read_path(MemoryCluster memories)
        {
            return Path.Combine(memories.get_read_path, _path);
        }
        public string h_write_path(MemoryCluster memories)
        {
            return Path.Combine(memories.get_write_path, _path);
        }
        public FileInfo h_read_file_info(MemoryCluster memories)
        {
            string path = h_read_path(memories);
            if (!File.Exists(path))
                throw new Exception("읽으려는 파일에 파일이 없습니다.");
            return new FileInfo(path);
        }
        public FileInfo h_write_file_info(MemoryCluster memories)
        {
            string path = h_write_path(memories);
            if (!File.Exists(path))
                throw new Exception("쓰려는 파일에 파일이 없습니다.");
            return new FileInfo(path);
        }
        public DirectoryInfo h_read_directory_info(MemoryCluster memories)
        {
            string path = h_read_path(memories);
            if (!Directory.Exists(path))
                throw new Exception("읽으려는 디렉토리에 디렉토리가 없습니다.");
            return new DirectoryInfo(path);
        }
        public DirectoryInfo h_write_directory_info(MemoryCluster memories)
        {
            string path = h_write_path(memories);
            if (!Directory.Exists(path))
                throw new Exception("쓰려는 디렉토리에 디렉토리가 없습니다.");
            return new DirectoryInfo(path);
        }
    }
}