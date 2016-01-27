using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IProjectBal
    {
        IEnumerable<Project> GetAll();
        Project GetById(int id);
        Project Create(Project objProject);
        Project Update(Project objProject);
        int? Delete(int id);
        List<Project> GetProjectsByClientId(string clientId);
    }
}
