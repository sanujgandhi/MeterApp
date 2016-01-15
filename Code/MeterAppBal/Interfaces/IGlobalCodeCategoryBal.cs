using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IGlobalCodeCategoryBal
    {
        IEnumerable<GlobalCodeCategory> GetAll();
        GlobalCodeCategory GetById(int id);
        GlobalCodeCategory Create(GlobalCodeCategory objGlobalCodeCategory);
        GlobalCodeCategory Update(GlobalCodeCategory objGlobalCodeCategory);
        GlobalCodeCategory Delete(GlobalCodeCategory objGlobalCodeCategory);
    }
}
