using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Device;

namespace EntityFrameworkTryBLL
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository DeviceRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeviceService(IDeviceRepository DeviceRepository, IUnitOfWork unitOfWork)
        {
            this.DeviceRepository = DeviceRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Device> GetDevices()
        {
            var Devices = DeviceRepository.GetMany(s => 1 == 1);
            return Devices;
        }
        public Device GetDevice(int id)
        {
            return DeviceRepository.GetById(id);
        }
        public void CreateDevice(Device Device)
        {
            DeviceRepository.Add(Device);
            unitOfWork.Commit();
        }
    }
}
