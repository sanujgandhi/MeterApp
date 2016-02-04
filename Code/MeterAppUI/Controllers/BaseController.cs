using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MeterAppBal.Interfaces;
using MeterAppBal.Services;
using MeterAppEntity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MeterAppUI.Controllers
{
    public class BaseController : Controller
    {
        protected IGlobalCodeBal iglobalCodeBal;
        protected IDeveloper_SkillBal ideveloperSkills;
        protected IProjectBal IProjectBal;
        protected IProject_ModuleBal IModuleBal;
        protected IFileUploadBal IFileUploadBal;
        protected IMessagesBal IMessagesBal;
        protected IProject_DeveloperBal IProject_DeveloperBal;
        protected IProject_TechnologyBal IProject_TechnologyBal;

        public BaseController()
        {
            if (iglobalCodeBal == null)
            {
                iglobalCodeBal = new GlobalCodeBal();
            }
            if (IProjectBal == null)
            {
                IProjectBal = new ProjectBal();
            }

            if (ideveloperSkills == null)
            {
                ideveloperSkills = new Developer_SkillBal();
            }

            if (IModuleBal == null)
            {
                IModuleBal = new Project_ModuleBal();
            }
            if (IFileUploadBal == null)
            {
                IFileUploadBal = new FileUploadBal();
            }
            if (IMessagesBal == null)
            {
                IMessagesBal = new MessagesBal();
            }
            if (IProject_DeveloperBal == null)
            {
                IProject_DeveloperBal = new Project_DeveloperBal();
            }
            if (IProject_TechnologyBal == null)
            {
                IProject_TechnologyBal = new Project_TechnologyBal();
            }
        }

        //GlobalCodeBal globalCodeBal = new GlobalCodeBal();
        //private GlobalCodeBal globalCodeBal;
        //public BaseController(IGlobalCodeBal iGlobalCodeBal)
        //{
        //    iGlobalCodeBal = globalCodeBal;
        //}

        //IGlobalCodeBal globalCodeBal = new GlobalCodeBal();


        private ApplicationUserManager _userManager;

        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return null;
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            return null;
        }
    }
}