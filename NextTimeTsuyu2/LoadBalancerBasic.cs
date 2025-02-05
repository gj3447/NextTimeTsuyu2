using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class LoadBalancerBasic : LoadBalancer
    {
        public LoadBalancerBasic(Backup backup) : base(backup)
        {
        }

        public override IModule get_module()
        {
            if (_backup.get_state == Backup.STATE.PRE_PROCESS || _backup.get_state == Backup.STATE.PROCESS)
            {
                if (_backup.get_module_cluster.
                        get_search_module
                    .h_state(_backup.get_memory_cluster, _backup.get_setting) == IModule.STATE.WORK)
                    return _backup.get_module_cluster.
                        get_search_module;

                if (_backup.get_module_cluster.
                    get_write_module
                    .h_state(_backup.get_memory_cluster, _backup.get_setting) == IModule.STATE.WORK)
                    return _backup.get_module_cluster.
                    get_write_module;

                if (_backup.get_module_cluster.
                        get_read_module
                    .h_state(_backup.get_memory_cluster, _backup.get_setting) == IModule.STATE.WORK)
                    return _backup.get_module_cluster.
                        get_read_module;
            }
            if (_backup.get_state == Backup.STATE.POST_PROCESS)
            {
                if (_backup.get_module_cluster.
                    get_swap_module
                    .h_state(_backup.get_memory_cluster, _backup.get_setting) == IModule.STATE.WORK)
                    return _backup.get_module_cluster.
                    get_swap_module;
            }
            return null;
        }
    }
}
