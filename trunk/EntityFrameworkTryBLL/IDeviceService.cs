using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Device;


namespace EntityFrameworkTryBLL
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetDevices();
        Device GetDevice(int id);
    }
    
}
