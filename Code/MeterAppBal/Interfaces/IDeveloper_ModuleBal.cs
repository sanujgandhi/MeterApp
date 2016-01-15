using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IDeveloper_ModuleBal
    {
        IEnumerable<Developer_Module> GetAll();
        Developer_Module GetById(int id);
        Developer_Module Create(Developer_Module objDeveloperModule);
        Developer_Module Update(Developer_Module objDeveloperModule);
        Developer_Module Delete(Developer_Module objDeveloperModule);
    }
}
