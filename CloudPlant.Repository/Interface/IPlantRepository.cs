using CloudPlant.Domain.Domain_models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Repository.Interface
{
    public interface IPlantRepository
    {
        void Insert(Plant entity);
        void Update(Plant entity);
        void Delete(Plant entity);
        Plant GetById(int id);

    }
}
