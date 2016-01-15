using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MeterAppBal.Interfaces;
using MeterAppBal.Services;
using MeterAppDal;
using MeterAppEntity.Model;
using MeterAppUI.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MeterAppUI.Controllers
{
    public class AdminController : BaseController
    {
        #region Users
        // GET: Clients View
        public ActionResult Index()
        {
            return View();
        }

        //Get: get Clients if id is 2 and get Developers if id is 3.
        public ActionResult GetUsers(string id)
        {
            using (MeterContext context = new MeterContext())
            {
                List<ApplicationUser> userList = null;
                userList = context.Users.Where(u => u.Roles.Any(r => r.RoleId == id)).ToList();
                return Json(userList, JsonRequestBehavior.AllowGet);
            }

        }

        //Post: Add User
        public async Task<string> AddUser(UserViewModel model)
        {

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                JoinDate = DateTime.Now.Date,
                PhoneNumber = "1234567890",
                LockoutEndDateUtc = DateTime.UtcNow,
                Level = 3
            };

            IdentityResult result = await this.UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var error = GetErrorResult(result);
                return error.ToString();
            }
            if (model.Role == "2")
            {
                var assignedRole = UserManager.AddToRoleAsync(user.Id, "Client");
            }
            if (model.Role == "3")
            {
                var assignedRole = UserManager.AddToRoleAsync(user.Id, "Developer");
                var newskills = new List<Developer_Skill>();
                foreach (var items in model.SkillList)
                {
                    var skills = new Developer_Skill()
                    {
                        SkillId = items.GlobalCodeId,
                        DeveloperId = user.Id,
                        CreatedBy = 1,
                        UpdatedBy = 1
                    };
                    newskills.Add(skills);
                }
                var skilles = ideveloperSkills.Create(newskills);
            }
            return "Client added successfull";
        }

        //Post: Update in user table
        public async Task<string> UpdateUser(UserViewModel model)
        {
            var user = await UserManager.FindByNameAsync(model.UserName);
            String hashedNewPassword = UserManager.PasswordHasher.HashPassword(model.Password);
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.PhoneNumber = model.PhoneNumber;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.PasswordHash = hashedNewPassword;
            var result = await UserManager.UpdateAsync(user);
            if (model.Role == "3")
            {
                var newskills = new List<Developer_Skill>();
                foreach (var items in model.SkillList)
                {
                    var skills = new Developer_Skill()
                    {
                        SkillId = items.GlobalCodeId,
                        DeveloperId = user.Id,
                        CreatedBy = 1,
                        UpdatedBy = 1
                    };
                    newskills.Add(skills);
                }
                var skilles = ideveloperSkills.Update(newskills);
            }
            return ("User is successfully updated");


        }

        //Post: Delete in user table
        public async Task<string> DeleteUser(string id)
        {
                var user = await this.UserManager.FindByIdAsync(id);
                if (user != null)
                {
                    IdentityResult result = await this.UserManager.DeleteAsync(user);
                    if (!result.Succeeded)
                    {
                        var data = GetErrorResult(result);
                        return data.ToString();
                    }
                    var skills = ideveloperSkills.GetById(id);
                    var resultSkills = ideveloperSkills.Delete(skills);
                    if (resultSkills == true)
                    {
                        return "Success";
                    }
            }
            return "user not found";
        }

        //Get: Developers View
        public ActionResult Developers()
        {

            //var result = iglobalCodeBal.GetAll();
            return View();
        }

        public ActionResult GetDevelopersSkills(int id)
        {

            var result = iglobalCodeBal.GetAll(id);
            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public ActionResult GetDeveloperSkillsById(string id)
        {
            var result = ideveloperSkills.GetById(id);
            if (result != null)
            {
                var listSkills = new List<GlobalCode>();
                foreach (var item in result)
                {
                    var skills = iglobalCodeBal.GetById(item.SkillId);
                    listSkills.Add(skills);
                }
                return Json(listSkills, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Project
        public ActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project modelProject)
        {
            if (!ModelState.IsValid)
            {
                return View(modelProject);
            }
            using (var projectBal = new ProjectBal())
            {
                projectBal.Create(modelProject);
            }
            return View();
        }
        #endregion


    }
}
