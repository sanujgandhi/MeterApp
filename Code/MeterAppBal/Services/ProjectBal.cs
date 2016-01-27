using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;
using MeterAppDal;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class ProjectBal : BaseBal, IProjectBal
    {
        public MeterAppEntity.Model.Project GetById(int id)
        {
            using (var repo = UnitOfWork.GenericRepository<Project>())
            {
                var result = repo.Where(p => p.ProjectId == id).FirstOrDefault();
                return result;
            }

        }

        public MeterAppEntity.Model.Project Create(MeterAppEntity.Model.Project objProject)
        {
            using (var repo = UnitOfWork.GenericRepository<Project>())
            {
                repo.AutoSave = true;
                var result = repo.Create(objProject);
                if (result == 1)
                {
                    return objProject;
                }
                else
                {
                    return null;
                }
            }
        }

        public MeterAppEntity.Model.Project Update(MeterAppEntity.Model.Project objProject)
        {
            using (var repo = UnitOfWork.GenericRepository<Project>())
            {
                repo.AutoSave = true;
                var result = repo.Update(objProject);
                if (result == 1)
                {
                    return objProject;
                }
                else
                {
                    return null;
                }
            }
        }

        public int? Delete(int id)
        {
            using (var repo = UnitOfWork.GenericRepository<Project>())
            {
                repo.AutoSave = true;
                var result = repo.Delete(id);
                return result;
            }
        }

        public IEnumerable<MeterAppEntity.Model.Project> GetAll()
        {
            using (var repo = UnitOfWork.GenericRepository<Project>())
            {
                repo.DatabaseContext.Database.Log = Console.Write;
                var result = repo.GetAll().Include(c=> c.ApplicationUser).ToList();
                //var sql = ((System.Data.Objects.ObjectQuery)result).ToTraceString();
                //using (var context = new MeterContext())
                //{
                //    context.Database.Log = Console.Write;
                //}
                return result;
            }
        }

        public List<Project> GetProjectsByClientId(string clientId)
        {
            if(clientId==null)
            {
                return null;
            }
            using(var repo=UnitOfWork.GenericRepository<Project>())
            {
                var result = repo.Where(a => a.ClientId == clientId).ToList();
                return result;
            }
        }
    }
}
