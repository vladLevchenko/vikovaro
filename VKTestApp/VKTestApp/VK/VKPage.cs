using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VKTestApp.VK
{
    public class VKPage : InfoPoint
    {
        public override int InfoPointID { get; set; }
        
        public override string Name { get; set; }
        public override string ImageLink { get; set; }
    }
}
