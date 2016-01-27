using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class ModuleBal:BaseBal, IModuleBal
    {
        

        public MeterAppEntity.Model.Module GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Module Create(MeterAppEntity.Model.Module objModule)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Module Update(MeterAppEntity.Model.Module objModule)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Module Delete(MeterAppEntity.Model.Module objModule)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.Module> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<string> GetdevelopersIdByProjectId(int projectId)
        {
            using (var repo = UnitOfWork.GenericRepository<Module>())
            {
                var result = repo.Where(a=>a.ProjectId==projectId && a.IsDeleted==false).Select(a=>a.DeveloperId).ToList();
                var abs = result.Distinct().ToList();
                if (abs != null)
                {
                    return abs;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<string> GetModulesNameByProjectIdAndDeveloperId(int projectId,string developerId)
        {
            using (var repo = UnitOfWork.GenericRepository<Module>())
            {
                var result = repo.Where(a => a.ProjectId == projectId && a.IsDeleted == false && a.DeveloperId==developerId).Select(a=>a.Name).ToList();
                if (result != null)
                {
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
