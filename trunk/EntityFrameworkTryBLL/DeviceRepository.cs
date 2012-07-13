using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Device;

namespace EntityFrameworkTryBLL
{
    public class DeviceRepository :RepositoryBase<Device>, IDeviceRepository
    {
            public DeviceRepository(IDatabaseFactory databaseFactory)
                : base(databaseFactory)
            {
            }
       
    }
}
