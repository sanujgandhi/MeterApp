using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;

namespace MeterAppBal.Services
{
    public class MessagesBal:BaseBal, IMessagesBal
    {
        

        public MeterAppEntity.Model.Messages GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Messages Create(MeterAppEntity.Model.Messages objMessages)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Messages Update(MeterAppEntity.Model.Messages objMessages)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Messages Delete(MeterAppEntity.Model.Messages objMessages)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.Messages> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
