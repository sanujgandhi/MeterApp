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
        protected IModuleBal IModuleBal;

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
                IModuleBal = new ModuleBal();
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