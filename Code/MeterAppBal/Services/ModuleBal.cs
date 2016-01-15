using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;

namespace MeterAppBal.Services
{
    public class ModuleBal:BaseBal, IModuleBal
    {
        

        public MeterAppEntity.Model.Module GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Module Create(MeterAppEntity.Model.Module objModule)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Module Update(MeterAppEntity.Model.Module objModule)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Module Delete(MeterAppEntity.Model.Module objModule)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.Module> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
