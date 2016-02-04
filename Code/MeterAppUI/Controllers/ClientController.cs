using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MeterAppUI.ViewModels;
using MeterAppEntity.Model;
using Newtonsoft.Json;
using System.IO;
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
        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult GetMessagesBYSenderIdReceiverIdAndProjectId(string senderId, string receiverId, int pojectId)
        {
            var result = IMessagesBal.GetMessageBySenderIdReceiverIdandProjectId(senderId, receiverId, pojectId);
            var fileNameList= new List<string>();
            foreach (var item in result)
            {
                if (item.MessageType != "text")
                {
                    var split = item.MessageType.Split(new string[] { "\\FileUploads\\" }, StringSplitOptions.None);
                    var fileName = item.MessageType.Split(new string[] { "_" }, StringSplitOptions.None).Last();
                    fileNameList.Add(fileName);
                    item.MessageType = split[1];
                }
            }
            var obj = new { messages = result, filename = fileNameList };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DownloadFile(string fileName)
        {
            string filePath = Server.MapPath("~") + "\\FileUploads\\" + fileName;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string path = Server.MapPath("~") + "\\downloads\\" + fileName;
            System.IO.File.WriteAllBytes(path, fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult GetDevelopersByProjectId(int id)
        {
            var result = IProject_DeveloperBal.GetdevelopersIdByProjectId(id);
            var usersList = new List<ApplicationUser>();
            var developersList = new List<DeveloperModule>();
            foreach (var item in result)
            {
                var user = UserManager.FindById(item.DeveloperId);
                var data = new DeveloperModule()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.Id,
                };
                developersList.Add(data);
            }

            return Json(developersList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult fileupload(HttpPostedFileBase data, FileUploadViewModel test)
        {
            var fileupload = new Messages();
            if (data != null && data.ContentLength > 0)
            {
                if (test.Description == "undefined")
                {
                    test.Description = null;
                }
                var date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-tt");
                string fileName = test.ClientId + "_" + test.DeveloperId + "_" + date + "_" + data.FileName;
                string path = Server.MapPath("~") + "\\FileUploads\\" + fileName;
                data.SaveAs(path);
                var messages = new Messages()
                {
                    SenderId = test.ClientId,
                    RecieverId = test.DeveloperId,
                    ProjectId = int.Parse(test.ProjectId),
                    TimeStamp = DateTime.UtcNow,
                    MessageType = path,
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                fileupload = IMessagesBal.Create(messages);
                if (test.Description == null)
                {
                    //GetMessagesBYSenderIdReceiverIdAndProjectId(test.ClientId, test.ModuleId, (int)test.ProjectId);
                    return Json(fileupload, JsonRequestBehavior.AllowGet);
                }
            }
            var message = new Messages()
            {
                ProjectId = int.Parse(test.ProjectId),
                SenderId = test.ClientId,
                RecieverId = test.DeveloperId,
                Message = test.Description,
                TimeStamp = DateTime.UtcNow,
                CreatedBy = 1,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                MessageType = "text"
            };
            var createMessage = IMessagesBal.Create(message);
            if(data!=null&&createMessage!=null)
            {
                var returnData = new { fileuploadobj = fileupload, messageobj = createMessage };
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            if (createMessage != null)
            {
                return Json(createMessage, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


    }
}