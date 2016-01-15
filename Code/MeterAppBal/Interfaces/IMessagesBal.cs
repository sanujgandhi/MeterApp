using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IMessagesBal
    {
        IEnumerable<Messages> GetAll();
        Messages GetById(int id);
        Messages Create(Messages objMessages);
        Messages Update(Messages objMessages);
        Messages Delete(Messages objMessages);
    }
}
