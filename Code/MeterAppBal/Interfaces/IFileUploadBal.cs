using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IFileUploadBal
    {
        IEnumerable<FileUpload> GetAll();
        FileUpload GetById(int id);
        FileUpload Create(FileUpload objFileUpload);
        FileUpload Update(FileUpload objFileUpload);
        FileUpload Delete(FileUpload objFileUpload);
    }
}
