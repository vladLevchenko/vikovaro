using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data
{
    public abstract class InfoPoint
    {
        public abstract int InfoPointID { get; set; }
        public abstract string Name { get; set; }

        public abstract string ImageLink { get; set; }
    }
}
