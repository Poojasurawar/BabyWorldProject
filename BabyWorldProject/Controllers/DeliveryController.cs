using BabyWorldProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BabyWorldProject.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveDelivery(DeliveryModel model)
        {
            try
            {
                return Json(new { Message = (new DeliveryModel().SaveDelivery(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeliveryList(DeliveryModel model)
        {
            try
            {
                return Json(new { Message = (new DeliveryModel().DeliveryList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {model=ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteDelivery(int DeliveryID)
        {
            try
            {
                return Json(new { Message = (new DeliveryModel().DeleteDelivery(DeliveryID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditDelivery(int DeliveryID)
        {
            try
            {
                return Json(new { Message = (new DeliveryModel().EditDelivery(DeliveryID)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}