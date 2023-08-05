using BabyWorldProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BabyWorldProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult SaveCategory(CategoryModel model) 
        {
            try
            {
                return Json(new { Message = (new CategoryModel().SaveCategory(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex) 
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetList(CategoryModel model)
        {
            try
            {
                return Json(new { Message = (new CategoryModel().GetCategoriesList()) },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new {model=ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteCategory(int CategoryID)
        {
            try
            {
                return Json(new { Message = (new CategoryModel().DeleteCategory(CategoryID)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EditCategory(int CategoryID) 
        {
            try
            {
                return Json(new { model = (new CategoryModel().EditCategory(CategoryID)) },
                               JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new {model=ex.Message }, JsonRequestBehavior.AllowGet);
            }
           
        }
    }
}