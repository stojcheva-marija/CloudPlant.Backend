using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.Identity;
using CloudPlant.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Repository.Implementation
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext context;
        private DbSet<Device> entities;

        public DeviceRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<Device>();
        }

        public void Insert(Device entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public Device GetById(int id)
        {
            return entities.Where(d => d.Id == id).Include(d => d.User).Include(d => d.Plants).FirstOrDefault();
        }

        public Device GetByCode(string code)
        {
            return entities.Where(d => d.Code == code).Include(d => d.User).Include(d => d.Plants).Include("Plants.PlantType").FirstOrDefault();
        }

        public void Update(Device entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            context.SaveChanges();
        }
        public void Delete(Device entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<Device> GetAll()
        {
            return entities.ToList();
        }
    }
}
