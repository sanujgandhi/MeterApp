using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppBal.Interfaces
{
    public interface IProject_SkillBal
    {
        IEnumerable<Project_Skill> GetAll();
        Project_Skill GetById(int id);
        Project_Skill Create(Project_Skill objProjectSkill);
        Project_Skill Update(Project_Skill objProjectSkill);
        Project_Skill Delete(Project_Skill objProjectSkill);
    }
}
