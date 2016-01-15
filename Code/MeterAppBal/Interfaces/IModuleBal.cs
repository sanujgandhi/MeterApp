using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IModuleBal
    {
        IEnumerable<Module> GetAll();
        Module GetById(int id);
        Module Create(Module objModule);
        Module Update(Module objModule);
        Module Delete(Module objModule);
    }
}
