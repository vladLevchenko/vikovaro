using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKTestApp.VK
{
    public class VKUser : NetworkUser
    {
        public override string ID { get; set; }

        public override string Token { get; set; }
        
    }
}
