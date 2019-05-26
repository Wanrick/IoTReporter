using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDevice
{class DeviceObject
    {
        internal string DeviceName { get; set; }
        internal string DeviceKey { get; set; }

        public override string ToString()
        {
            return DeviceName;
        }
    }
}
