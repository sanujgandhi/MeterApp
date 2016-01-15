using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppBal.Interfaces;

namespace MeterAppBal.Services
{
    public class FileUploadBal:BaseBal, IFileUploadBal
    {
        

        public MeterAppEntity.Model.FileUpload GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MeterAppEntity.Model.FileUpload Create(MeterAppEntity.Model.FileUpload objFileUpload)
        {
            throw new NotImplementedException();
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
