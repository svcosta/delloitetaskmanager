using Delloite.TaskManager.DataTransferObject;
using Delloite.TaskManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.UI.Web.App_Start;

namespace TaskManager.UI.Web.Controllers
{
   
    public class TaskController : Controller
    {
        ITaskService _taskService;       

        public ActionResult Index()
        {           
            return View();
        }
        
        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        [ValidationToken]
        // GET: Task
        public JsonResult GetMyTasks(Int32 id)
        {
            var taskList = this._taskService.GetAllByUser(id);
            return Json(taskList, JsonRequestBehavior.AllowGet);
        }

        [ValidationToken]
        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            object returnObj;
            try
            {
                this._taskService.Remove(id);

                returnObj = new { result = true, msg = "Task successfully removed!" };
               
            }
            catch (Exception ex)
            {
                returnObj = new { result = false, msg = ex.Message };               
            }

            return Json(returnObj, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [ValidationToken]
        [HttpPost]
        public JsonResult Create(TaskDTO dto)
        {
            object returnObj;
            try
            {               
                this._taskService.Create(dto);
                returnObj = new { result = true, msg = "Task successfully Create!" };

            }
            catch (Exception ex)
            {
                returnObj = new { result = false, msg = ex.Message };
            }

            return Json(returnObj, JsonRequestBehavior.AllowGet);
        }

      
        public ActionResult Edit(Int32 id)
        {
            var model = this._taskService.GetTask(id);
            return View(model);
        }

        [ValidationToken]
        [HttpPost]
        public JsonResult Edit(TaskDTO dto)
        {
            object returnObj;
            try
            {
                this._taskService.Update(dto);
                returnObj = new { result = true, msg = "Task successfully Update!" };

            }
            catch (Exception ex)
            {
                returnObj = new { result = false, msg = ex.Message };
            }

            return Json(returnObj, JsonRequestBehavior.AllowGet);
        }

    }
}