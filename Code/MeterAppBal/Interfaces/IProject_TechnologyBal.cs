using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IProject_TechnologyBal
    {
        IEnumerable<Project_Technology> GetAll();
        Project_Technology GetById(int id);
        Project_Technology Create(Project_Technology objProjectTechnology);
        Project_Technology Update(Project_Technology objProjectTechnology);
        Project_Technology Delete(Project_Technology objProjectTechnology);

    }
}
