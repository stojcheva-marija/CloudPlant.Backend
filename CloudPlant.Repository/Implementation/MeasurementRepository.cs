using CloudPlant.Domain.Domain_models;
using CloudPlant.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Repository.Implementation
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly AppDbContext context;
        private DbSet<Measurement> entities;

        public MeasurementRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<Measurement>();
        }

        public void Insert(Measurement entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public Measurement GetById(int id)
        {
            return entities.Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
