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
        void Update(Device entity);
        void Delete(Device entity);
        Device GetById(int id);
        Device GetByCode(string code);
    }
}
