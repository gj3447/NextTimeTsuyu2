﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextTimeTsuyu2
{
    public class LoadBalancerRand : LoadBalancer
    {
        public LoadBalancerRand(Backup backup) : base(backup)
        {
        }

        public override IModule get_module()
        {
            throw new NotImplementedException();
        }
    }
}
