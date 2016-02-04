using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class FileUploadBal:BaseBal, IFileUploadBal
    {
        

        public MeterAppEntity.Model.FileUpload GetById(int id)
        {
            using (var repo = UnitOfWork.GenericRepository<FileUpload>())
            {
               if(id!=null)
               {
                   var result = repo.Where(a => a.FileUploadId == id).FirstOrDefault();
                   return result;
               }
               else
               {
                   return null;
               }
            }
        }

        public MeterAppEntity.Model.FileUpload Create(MeterAppEntity.Model.FileUpload objFileUpload)
        {
            using (var repo = UnitOfWork.GenericRepository<FileUpload>())
            {
              if(objFileUpload!=null)
              {
                  repo.AutoSave = true;
                  repo.Create(objFileUpload);
                  return objFileUpload;
              }
              else
              {
                  return null;
              }
            }
        }

        public MeterAppEntity.Model.FileUpload Update(MeterAppEntity.Model.FileUpload objFileUpload)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.FileUpload Delete(MeterAppEntity.Model.FileUpload objFileUpload)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeterAppEntity.Model.FileUpload> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
