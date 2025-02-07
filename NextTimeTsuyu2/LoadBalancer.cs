using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public abstract class LoadBalancer
    {
        protected Backup _backup;
        public LoadBalancer(Backup backup)
        {
            _backup = backup;
        }
        public abstract NextTimeTsuyu2.IModule get_module();

        public static LoadBalancer h_create_loadbalancer(Backup backup,LoadBalancer.TYPE type )
        {
            switch (type)
            {
                case LoadBalancer.TYPE.RAND:
                    return new LoadBalancerRand(backup);
                case LoadBalancer.TYPE.PRIORITY:
                    return new LoadBalancerPriority(backup);
                case LoadBalancer.TYPE.BASIC:
                    return new LoadBalancerBasic(backup);
                default:
                    return new LoadBalancerBasic(backup);
            }
        }
        public enum TYPE
        {
            RAND,
            PRIORITY,
            BASIC
        }
    }
}
