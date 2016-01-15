using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IGlobalCodeBal
    {
        List<GlobalCode> GetAll(int id);
        GlobalCode GetById(int id);
        GlobalCode Create(GlobalCode objGlobalCode);
        GlobalCode Update(GlobalCode objGlobalCode);
        GlobalCode Delete(GlobalCode objGlobalCode);

    }
}
