using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;

namespace MeterAppBal.Services
{
    public class ProjectBal:BaseBal, IProjectBal
    {
        public MeterAppEntity.Model.Project GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project Create(MeterAppEntity.Model.Project objProject)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project Update(MeterAppEntity.Model.Project objProject)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.Project Delete(MeterAppEntity.Model.Project objProject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.Project> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
