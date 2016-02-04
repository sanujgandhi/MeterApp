using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MeterAppBal.Interfaces;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class Project_TechnologyBal : BaseBal, IProject_TechnologyBal
    {

        public MeterAppEntity.Model.Project_Technology GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project_Technology Create(MeterAppEntity.Model.Project_Technology objProjectTechnology)
        {
            using (var repo = UnitOfWork.GenericRepository<Project_Technology>())
            {
                repo.AutoSave = true;
                repo.Create(objProjectTechnology);
                return objProjectTechnology;
            }
        }

        public List<MeterAppEntity.Model.Project_Technology> Create(List<MeterAppEntity.Model.Project_Technology> objProjectTechnology)
        {
            using (var transaction = new TransactionScope())
            {
                using (var repo = UnitOfWork.GenericRepository<Project_Technology>())
                {
                    repo.AutoSave = true;
                    repo.Create(objProjectTechnology);
                }
                transaction.Complete();
                return objProjectTechnology;
            }

        }

        public MeterAppEntity.Model.Project_Technology Update(MeterAppEntity.Model.Project_Technology objProjectTechnology)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project_Technology Delete(MeterAppEntity.Model.Project_Technology objProjectTechnology)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.Project_Technology> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project_Technology> GetByProjectId(int id)
        {
            using (var repo = UnitOfWork.GenericRepository<Project_Technology>())
            {
                return repo.GetAll().Where(l => l.ProjectId.Equals(id)).ToList();
            }


        }
    }
}
