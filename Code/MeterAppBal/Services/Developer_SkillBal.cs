using System;
using System.Collections.Generic;
using System.Linq;
using MeterAppBal.Interfaces;
using MeterAppEntity.Model;

namespace MeterAppBal.Services
{
    public class Developer_SkillBal : BaseBal, IDeveloper_SkillBal
    {

        public List<MeterAppEntity.Model.Developer_Skill> GetById(string id)
        {
            using (var repo = UnitOfWork.GenericRepository<Developer_Skill>())
            {
                var result = repo.Where(a => a.DeveloperId == id).ToList();
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

        public List<MeterAppEntity.Model.Developer_Skill> Create(List<MeterAppEntity.Model.Developer_Skill> developerSkill)
        {
            if (developerSkill != null)
            {
                using (var repo = UnitOfWork.GenericRepository<Developer_Skill>())
                {
                    var data = new object();
                    foreach (var items in developerSkill)
                    {
                        repo.AutoSave = true;
                        var result = repo.Create(items);
                        data = result;
                    }
                    if (data != null)
                    {
                        return developerSkill;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }

        }

        public List<MeterAppEntity.Model.Developer_Skill> Update(List<MeterAppEntity.Model.Developer_Skill> objDeveloperSkill)
        {
            if (objDeveloperSkill != null)
            {
                using (var transcope = new System.Transactions.TransactionScope())
                {
                    using (var repo = UnitOfWork.GenericRepository<Developer_Skill>())
                    {
                        var data = new object();
                        var newDelete = new List<Developer_Skill>();
                        foreach (var items in objDeveloperSkill)
                        {
                            var delete = repo.Where(a => a.DeveloperId == items.DeveloperId && a.SkillId == items.SkillId).FirstOrDefault();
                            if (delete != null)
                            {
                                newDelete.Add(delete);
                            }
                        }
                        foreach (var item in newDelete)
                        {
                            var result = repo.Delete(item);
                        }
                        foreach (var items in objDeveloperSkill)
                        {
                            repo.AutoSave = true;
                            var result = repo.Create(items);
                            data = result;
                        }
                        if (data != null)
                        {
                            transcope.Complete();
                            return objDeveloperSkill;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public bool Delete(List<MeterAppEntity.Model.Developer_Skill> objDeveloperSkill)
        {
            if (objDeveloperSkill != null)
            {
                using (var repo = UnitOfWork.GenericRepository<Developer_Skill>())
                {
                    foreach (var item in objDeveloperSkill)
                    {
                        repo.AutoSave = true;
                        repo.Delete(item);
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<MeterAppEntity.Model.Developer_Skill> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
