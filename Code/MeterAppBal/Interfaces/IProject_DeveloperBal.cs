using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IProject_DeveloperBal
    {
        IEnumerable<Project_Developer> GetAll();
        Project_Developer GetById(int id);
        Project_Developer Create(Project_Developer objDeveloperModule);
        Project_Developer Update(Project_Developer objDeveloperModule);
        Project_Developer Delete(Project_Developer objDeveloperModule);
        List<Project_Developer> GetdevelopersIdByProjectId(int projectId);
    }
}
