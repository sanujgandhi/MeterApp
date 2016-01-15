using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class GlobalCodeBal:BaseBal, IGlobalCodeBal
    {
       

        public MeterAppEntity.Model.GlobalCode GetById(int id)
        {
            using (var repo = UnitOfWork.GenericRepository<GlobalCode>())
            {
                var result = repo.Where(a => a.GlobalCodeId == id).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public MeterAppEntity.Model.GlobalCode Create(MeterAppEntity.Model.GlobalCode objGlobalCode)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.GlobalCode Update(MeterAppEntity.Model.GlobalCode objGlobalCode)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.GlobalCode Delete(MeterAppEntity.Model.GlobalCode objGlobalCode)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// this method is used to get a list on the basis of GlobalCodeId.
        /// </summary>  
        /// <param name="id">GlobalCodeId</param>
        /// <returns></returns>
        public List<MeterAppEntity.Model.GlobalCode> GetAll(int id)
        {
            using (var repo = UnitOfWork.GenericRepository<GlobalCode>())
            {
                var result = repo.Where(a=>a.GlobalCodeCategoryId==id).ToList();
                if(result!=null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
