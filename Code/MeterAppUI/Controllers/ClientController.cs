using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MeterAppUI.ViewModels;
using MeterAppEntity.Model;
namespace MeterAppUI.Controllers
{
    public class ClientController : BaseController
    {

        // GET: Client
        public ActionResult Index()
        {
            var viewModel = new ClientViewModel();
            if (Request.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = UserManager.FindByName(userName);
                var project = IProjectBal.GetProjectsByClientId(user.Id.ToString());
                viewModel.ClientsProject = project;
                return View(viewModel);
            }
            return null;

        }

        public ActionResult Messages(string userName)
        {
            return PartialView("_Messages");

        }

        public ActionResult GetDevelopersByProjectId(int id)
        {
            var result = IModuleBal.GetdevelopersIdByProjectId(id);
            var usersList = new List<ApplicationUser>();
            var developersList = new List<DeveloperModule>();
            foreach (var item in result)
            {
                var user = UserManager.FindById(item);
                var listModules = IModuleBal.GetModulesNameByProjectIdAndDeveloperId(id, item);
                var data = new DeveloperModule()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.Id,
                    Module = listModules,
                };
                developersList.Add(data);
            }

            return Json(developersList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult fileupload(object data)
        {
            return null;
        }


    }
}