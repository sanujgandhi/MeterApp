using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IProject_ModuleBal
    {
        IEnumerable<Project_Module> GetAll();
        Project_Module GetById(int id);
        Project_Module Create(Project_Module objModule);
        Project_Module Update(Project_Module objModule);
        Project_Module Delete(Project_Module objModule);
        //List<string> GetdevelopersIdByProjectId(int projectId);
        //List<Project_Module> GetModulesNameByProjectIdAndDeveloperId(int projectId, string developerId);
    }
}
