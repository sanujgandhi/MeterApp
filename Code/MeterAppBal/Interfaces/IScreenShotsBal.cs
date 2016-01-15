using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IScreenShotsBal
    {
        IEnumerable<Screenshots> GetAll();
        Screenshots GetById(int id);
        Screenshots Create(Screenshots objScreenshots);
        Screenshots Update(Screenshots objScreenshots);
        Screenshots Delete(Screenshots objScreenshots);
    }
}
