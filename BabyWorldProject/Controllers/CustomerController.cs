using BabyWorldProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BabyWorldProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveCustomer(CutomerModel model)
        {
            try
            {
                return Json(new { Message = (new CutomerModel().SaveCustomer(model)) },
                               JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        

        }
        public ActionResult GetCustomerList(CutomerModel model)
        {
            try
            {
                return Json(new { Message = new CutomerModel().GetCustomerList() },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new {model=ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteCustomer(int CustomerID)
        {
            try
            {
                return Json(new { Message = new CutomerModel().DeleteCustomer(CustomerID) },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new {model= ex.Message },JsonRequestBehavior.AllowGet) ;
            }
        }
        public ActionResult EditCustomer(int CustomerID)
        {
            try
            {
                return Json(new { model = new CutomerModel().EditCustomer(CustomerID) },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}