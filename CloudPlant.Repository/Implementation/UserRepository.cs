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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        private DbSet<CloudPlantUser> entities;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<CloudPlantUser>();
        }

        public void Insert(CloudPlantUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public CloudPlantUser GetById(int id)
        {
            return entities.Where(u => u.Id == id).FirstOrDefault();
        }

        public CloudPlantUser GetByUsername(string username)
        {
            return entities.Where(u => u.Username == username).Include(u => u.Devices).FirstOrDefault();
        }
    }
}
