using Delloite.TaskManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.UI.Web.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        //the intance of userService will injecte by ninject.
        public UserController(IUserService userService)
        {
            //SOLID = I Independence Injection 
            this._userService = userService;
        }
        // GET: User
        [HttpPost]
        public JsonResult GetToken(string userName, string password)
        {
            try
            {
                var userSession = this._userService.GetUser(userName, password);
                return Json(userSession, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
        }    

    }
}