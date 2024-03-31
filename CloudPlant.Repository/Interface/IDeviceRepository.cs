using CloudPlant.Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Repository.Interface
{
    public interface IDeviceRepository
    {
        void Insert(Device entity);
        Device GetById(int id);
    }
}
