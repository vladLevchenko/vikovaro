using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKTestApp.VK
{
    public class APIMethod
    {
        
        private APIMethod(string value) { Value = value; }
        public string Value { get; set; }       

        
        public static APIMethod GetGroups { get { return new APIMethod("groups.get"); } }
        
    }
}
