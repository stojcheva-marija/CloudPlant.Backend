using CloudPlant.Domain.Domain_models;
using CloudPlant.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Repository.Implementation
{
    public class PlantRepository : IPlantRepository
    {
        private readonly AppDbContext context;
        private DbSet<Plant> entities;

        public PlantRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<Plant>();
        }

        public void Delete(Plant entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public Plant GetById(int id)
        {
            Plant plant = entities.Where(p => p.Id == id).Include(p => p.PlantType).Include(p => p.Device).Include(p => p.Measurements).FirstOrDefault();
            return plant;
        }

        public void Insert(Plant entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Plant entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            context.SaveChanges();
        }

    }
}
