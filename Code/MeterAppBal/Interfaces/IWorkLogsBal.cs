using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IWorkLogsBal
    {
        IEnumerable<WorkLogs> GetAll();
        WorkLogs GetById(int id);
        WorkLogs Create(WorkLogs objWorkLogs);
        WorkLogs Update(WorkLogs objWorkLogs);
        WorkLogs Delete(WorkLogs objWorkLogs);
    }
}
