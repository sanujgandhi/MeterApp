using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;

namespace MeterAppBal.Services
{
    public class WorkLogsBal : BaseBal, IWorkLogsBal
    {
        public IEnumerable<MeterAppEntity.Model.WorkLogs> GetAll()
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.WorkLogs GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.WorkLogs Create(MeterAppEntity.Model.WorkLogs objWorkLogs)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.WorkLogs Update(MeterAppEntity.Model.WorkLogs objWorkLogs)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.WorkLogs Delete(MeterAppEntity.Model.WorkLogs objWorkLogs)
        {
            throw new NotImplementedException();
        }
    }
}
