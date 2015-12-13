using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data
{
    public abstract class NetworkUser
    {
        public abstract string Token { get; set; }
        public abstract string ID { get; set; }
    }
}
