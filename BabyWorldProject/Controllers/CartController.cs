using BabyWorldProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BabyWorldProject.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveCart(CartModel model) 
        {
            try
            {
                return Json(new { Message = (new CartModel().SaveCart(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex) 
            {
                return Json(new {model= ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetList(CartModel model)
        {
            try
            {
                return Json(new { Message = (new CartModel().GetCartList()) },
                    JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult RemoveItem(int cartid)
        {
            try
            {
                return Json(new { Message = (new CartModel().RemoveItem(cartid)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EditCart(int CartID)
        {
            try
            {
                return Json(new { model = (new CartModel().EditCart(CartID)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}