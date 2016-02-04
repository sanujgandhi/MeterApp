using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class Project_DeveloperBal:BaseBal, IProject_DeveloperBal
    {
        

        public MeterAppEntity.Model.Project_Developer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project_Developer Create(MeterAppEntity.Model.Project_Developer objDeveloperModule)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project_Developer Update(MeterAppEntity.Model.Project_Developer objDeveloperModule)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project_Developer Delete(MeterAppEntity.Model.Project_Developer objDeveloperModule)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.Project_Developer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Project_Developer> GetdevelopersIdByProjectId(int projectId)
        {
            using(var repo=UnitOfWork.GenericRepository<Project_Developer>()){
                if(projectId!=null)
                {
                    var result = repo.Where(a => a.ProjectId == projectId).ToList();
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
