using BabyWorldProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace BabyWorldProject.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderDate { get; set; }
        public string PaymentMode { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal IGST { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryPerson { get; set; }

        public string SaveOrder(OrderModel model)
        {
            string msg = "Save Successfully";
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            if (model.OrderID == 0)
            {
                var OrderData = new tblOrder()
                {
                    OrderID = model.OrderID,
                    CustomerID = model.CustomerID,
                    Amount = model.Amount,
                    Discount = model.Discount,
                    TotalAmount = model.TotalAmount,
                    OrderDate = Convert.ToDateTime(model.OrderDate),
                    PaymentMode = model.PaymentMode,
                    SGST = model.SGST,
                    CGST = model.CGST,
                    IGST = model.IGST,
                    DeliveryDate = Convert.ToDateTime(model.DeliveryDate),
                    DeliveryPerson = model.DeliveryPerson,
                };
                db.tblOrders.Add(OrderData);
                db.SaveChanges();

            }
            else
            {
                var OrderData = db.tblOrders.Where(p => p.OrderID == OrderID).FirstOrDefault();
                if (OrderData == null)
                {
                    OrderData.OrderID = model.OrderID;
                    OrderData.CustomerID = model.CustomerID;
                    OrderData.Amount = model.Amount;
                    OrderData.Discount = model.Discount;
                    OrderData.TotalAmount = model.TotalAmount;
                    OrderData.OrderDate= Convert.ToDateTime(model.OrderDate);
                    OrderData.PaymentMode = model.PaymentMode;
                    OrderData.SGST = model.SGST;
                    OrderData.CGST = model.CGST;
                    OrderData.IGST = model.IGST;
                    OrderData.DeliveryDate= Convert.ToDateTime(model.DeliveryDate);
                    OrderData.DeliveryPerson = model.DeliveryPerson;
                }
                db.SaveChanges();
                msg = "Updated uccessfully";
            }
            return msg;


        }

        public List<OrderModel> OrderList()
        {
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            List<OrderModel> lstorder = new List<OrderModel>();
            var OrderData = db.tblOrders.ToList();
            if (OrderData != null)
            {
                foreach (var item in OrderData)
                {
                    lstorder.Add(new OrderModel()
                    {
                       OrderID = item.OrderID,
                        CustomerID = item.CustomerID,
                        Amount = item.Amount,
                        Discount = item.Discount,
                        TotalAmount = item.TotalAmount,
                        OrderDate =Convert.ToString(item.OrderDate),
                        PaymentMode = item.PaymentMode,
                        SGST = item.SGST,
                        CGST = item.CGST,
                        IGST = item.IGST,
                        DeliveryDate= Convert.ToString(item.DeliveryDate),
                        DeliveryPerson = item.DeliveryPerson,

                    });
                }
            }
            return lstorder;
        }

        public OrderModel EditOrder(int OrderID)
        {
            OrderModel model= new OrderModel();
            BabyWorldProjectEntities db= new BabyWorldProjectEntities();
            var OrderData = db.tblOrders.Where(p => p.OrderID == OrderID).FirstOrDefault();
            if (OrderData != null)
            {
                model.OrderID = OrderData.OrderID;
                model.CustomerID = OrderData.CustomerID;
                model.Amount = OrderData.Amount;
                model.Discount = OrderData.Discount;
                model.TotalAmount = OrderData.TotalAmount;
                model.OrderDate=Convert.ToString(OrderData.OrderDate);
                model.PaymentMode = OrderData.PaymentMode;
                model.SGST = OrderData.SGST;
                model.CGST = OrderData.CGST;
                model.IGST = OrderData.IGST;
                model.DeliveryDate=Convert.ToString(OrderData.DeliveryDate);
                model.DeliveryPerson= OrderData.DeliveryPerson;
            };
            return model;
        }
    }
}
