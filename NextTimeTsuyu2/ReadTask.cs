using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class ReadTask : Task
    {
        public int _index { get; init; }

        public byte[] h_file_read(MemoryCluster memories, int chunk_size)
        {
            if (chunk_size <= 0)
                throw new ArgumentOutOfRangeException(nameof(chunk_size), "청크 크기는 0보다 커야 합니다.");
            if (memories == null) 
                throw new ArgumentNullException("메모리 클러스터가 없습니다.");

            FileInfo fileinfo = h_read_file_info(memories);
            long offset = (long)chunk_size * (long)_index;
            
            long file_size = fileinfo.Length;

            if (offset >= file_size)
                throw new EndOfStreamException("오프셋이 파일 크기를 초과합니다.");

            long remaining_bytes = file_size - offset;
            int bytes_to_read = (int)Math.Min(chunk_size, remaining_bytes);
            memories.h_read_byte_size(bytes_to_read);

            byte[] buffer = new byte[bytes_to_read];
            using (FileStream fs = new FileStream(fileinfo.FullName, FileMode.Open,FileAccess.Read,FileShare.Read))
            {
                fs.Seek(offset, SeekOrigin.Begin);
                int bytesRead = fs.Read(buffer, 0, bytes_to_read);
            }
            return buffer;
        }
    }
}
