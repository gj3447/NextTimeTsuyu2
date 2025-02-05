using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class SwapTask : Task
    {
        public string _temp_path { get; init; }

        public bool h_swap(MemoryCluster memories)
        {

            if (!File.Exists(_temp_path))
                throw new Exception("SWAPPING ERROR: Temp file does not exist.");

            if (File.Exists(_path))
                File.Delete(_path); // 기존 파일 삭제

            File.Move(_temp_path, _path); // temp_path를 path로 변경

            return true;
        }
    }
}
