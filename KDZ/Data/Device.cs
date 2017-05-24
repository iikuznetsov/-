using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ.Data
{
    class Device
    {
        public string Name { get; set; }
        public string Problem { get; set; }
        public static Device[] GetDevices()
        {
            var result = new Device[]
                {
                    new Device() { Name = "PC", Problem = "Damaged display" },
                    new Device() { Name = "iphone 3GS", Problem = "Uncorrect view" },
                    new Device() { Name = "Samsung 8S", Problem = "Disabled camera" }
                };
            return result;
        }
    }
}
