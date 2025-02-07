using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class ModuleCluster
    {
        #region field
        //PreProcessing
        private SearchModule _search_module;

        //Processing
        private ReadModule _read_module;
        private WriteModule _write_module;
        private DeleteReadModule _delete_read_module;

        //PostProcessing
        private SwapModule _swap_module;
        private DeleteWriteModule _delete_write_module;

        //StopProcessing
        private StopDirectoryModule _stop_directory_module;
        private StopFileSwapModule _stop_file_swap_module;
        #endregion

        #region property
        //PreProcessing
        public SearchModule get_search_module => _search_module;
        public IModule[] get_pre_process_module
        { get { return new IModule[1] { _search_module }; } }

        //Proccssing;
        public ReadModule get_read_module => _read_module;
        public WriteModule get_write_module => _write_module;
        public DeleteReadModule get_delete_read_module => _delete_read_module;
        public IModule[] get_processing_module
        { get { return new IModule[2] { _read_module,_write_module ,_delete_read_module }; } }

        //PostProcessing
        public SwapModule get_swap_module => _swap_module;
        public DeleteWriteModule get_delete_write_module => _delete_write_module;
        public IModule[] get_post_processing_module
        { get { return new IModule[2] { _swap_module, _delete_write_module }; } }

        //StopProcessing
        public StopDirectoryModule get_stop_directory_module => _stop_directory_module;
        public StopFileSwapModule get_stop_fileswap_module => _stop_file_swap_module;
        public IModule[] get_stop_module
        { get { return new IModule[2] { _stop_directory_module, _stop_file_swap_module }; } }
        #endregion

        public ModuleCluster()
        { 
            //PRE_PROCESS
            this._search_module = new SearchModule();

            //PROCESS
            this._read_module = new ReadModule();
            this._write_module = new WriteModule();
            this.

            //POST_PROCESS
            this._swap_module = new SwapModule();
            
            //STOP_PROCESS
            this._stop_directory_module = new StopDirectoryModule();
            this._stop_file_swap_module = new StopFileSwapModule();

        }
    }
}