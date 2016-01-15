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

        public BaseController()
        {
            this.iglobalCodeBal = new GlobalCodeBal();
            this.ideveloperSkills = new Developer_SkillBal();
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