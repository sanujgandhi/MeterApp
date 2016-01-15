using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IDeveloper_SkillBal
    {
        IEnumerable<Developer_Skill> GetAll();
        List<Developer_Skill> GetById(string id);
        List<Developer_Skill> Create(List<Developer_Skill> objDeveloperSkill);
        List<Developer_Skill> Update(List<Developer_Skill> objDeveloperSkill);
       bool Delete(List<Developer_Skill> objDeveloperSkill);
    }
}
