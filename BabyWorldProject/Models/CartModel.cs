using BabyWorldProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace BabyWorldProject.Models
{
    public class CartModel
    {
        public int CartID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

        public string SaveCart(CartModel model) 
        {
            string msg = "save successsfully";
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            if (model.CartID == 0)
            {
                var CartData = new tblCart()
                {
                    CartID = model.CartID,
                    OrderID = model.OrderID,
                    ProductID = model.ProductID,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    Amount = model.Amount,
                    Discount = model.Discount,
                };
                db.tblCarts.Add(CartData);
                db.SaveChanges();
            }
            else
            {
                var CartData = db.tblCarts.Where(p => p.CartID == model.CartID).FirstOrDefault();
                if (CartData != null)
                {
                    CartData.CartID=model.CartID;
                    CartData.OrderID = model.OrderID;
                    CartData.ProductID = model.ProductID;
                    CartData.Price = model.Price;
                    CartData.Quantity = model.Quantity;
                    CartData.Amount = model.Amount;
                    CartData.Discount = model.Discount;
                }
                db.SaveChanges();
                msg = "Updated Successfully";
            }
           
            return msg;
        }

        public List<CartModel> GetCartList()
        {
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            List<CartModel> lstcart = new List<CartModel>();

            var Cartdata = db.tblCarts.ToList();
            {
                if (Cartdata != null)
                {
                    foreach(var item in Cartdata) 
                    {
                        lstcart.Add(new CartModel()
                        {
                            CartID = item.CartID,
                            OrderID = item.OrderID,
                            ProductID = item.ProductID,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            Amount = item.Amount,
                            Discount = item.Discount,
                        });
                    }
                }
                return lstcart;
            }

           
        }
        public string RemoveItem(int cartid)
        {
            string msg = "";
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            var CartData = db.tblCarts.Where(p => p.CartID == cartid).FirstOrDefault();
            if(CartData != null)
            {
                db.tblCarts.Remove(CartData);
            }
            db.SaveChanges();
            msg = "Item Removed Successfully";
            return msg;
        }

        public CartModel EditCart(int CartID)
        {
           // string msg = "";
            CartModel model= new CartModel();
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            var CartData=db.tblCarts.Where(p=>p.CartID== CartID).FirstOrDefault();
            if(CartData != null)
            {
                model.CartID = CartData.CartID;
                model.OrderID = CartData.OrderID;
                model.ProductID = CartData.ProductID;
                model.Price = CartData.Price;
                model.Quantity = CartData.Quantity;
                model.Amount= CartData.Amount;
                model.Discount=CartData.Discount;
            };
            return model;
        }
    }
}