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
    public class PlantTypeRepository : IPlantTypeRepository
    {
        private readonly AppDbContext context;
        private DbSet<PlantType> entities;

        public PlantTypeRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<PlantType>();
        }

        public void Insert(PlantType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public PlantType GetById(int id)
        {
            return entities.Where(pt => pt.Id == id).FirstOrDefault();
        }
    }
}
