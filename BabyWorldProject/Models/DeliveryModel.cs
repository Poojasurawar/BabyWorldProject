using BabyWorldProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabyWorldProject.Models
{
    public class DeliveryModel
    {
        public int DeliveryID { get; set; }
        public int CustomerID { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public int Pincode { get; set; }
        public string Type { get; set; }

        public string SaveDelivery(DeliveryModel model)
        {
            string msg = "Save Successfully";
            BabyWorldProjectEntities db= new BabyWorldProjectEntities();
            if (model.DeliveryID == 0)
            {
                var DeliveryData = new tblDelivery1()
                {
                    DeliveryID = model.DeliveryID,
                    CustomerID = model.CustomerID,
                    PersonName = model.PersonName,
                    Address = model.Address,
                    City = model.City,
                    Landmark = model.Landmark,
                    Pincode = model.Pincode,
                    Type = model.Type,
                };
                db.tblDelivery1.Add(DeliveryData);
                db.SaveChanges();
            }
            else
            {
                var DeliveryData = db.tblDelivery1.Where(p => p.DeliveryID == model.DeliveryID).FirstOrDefault();
                if (DeliveryData != null)
                {
                    DeliveryData.DeliveryID = model.DeliveryID;
                    DeliveryData.CustomerID = model.CustomerID;
                    DeliveryData.PersonName = model.PersonName;
                    DeliveryData.Address = model.Address;
                    DeliveryData.City = model.City;
                    DeliveryData.Landmark = model.Landmark;
                    DeliveryData.Pincode = model.Pincode;
                    DeliveryData.Type = model.Type;
                }
                db.SaveChanges();
                msg = "Updated Successfully";
            }
            
            return msg;
        }

public List<DeliveryModel> DeliveryList()
        {
            BabyWorldProjectEntities db= new BabyWorldProjectEntities();
            List<DeliveryModel>lstdilivery= new List<DeliveryModel>();
            var DeliveryData = db.tblDelivery1.ToList();
            if ( DeliveryData != null )
            {
                foreach ( var item in DeliveryData)
                {
                    lstdilivery.Add(new DeliveryModel()
                    {
                        DeliveryID = item.DeliveryID,
                        CustomerID = item.CustomerID,
                        PersonName = item.PersonName,
                        Address = item.Address,
                        City = item.City,
                        Landmark = item.Landmark,
                        Pincode = item.Pincode,
                        Type = item.Type,

                    });
                }
            }
            return lstdilivery;
        }

        public string DeleteDelivery(int DeliveryID)
        {
            string msg = "";
            BabyWorldProjectEntities db=new BabyWorldProjectEntities();
            var DeliveryData = db.tblDelivery1.Where(p => p.DeliveryID == DeliveryID).FirstOrDefault();
            if ( DeliveryData != null )
            {
                db.tblDelivery1.Remove(DeliveryData);
            }
            db.SaveChanges();
            msg = "Data Deleted Successfully";
            return msg;
        }

        public DeliveryModel EditDelivery(int DeliveryID)
        {
            DeliveryModel model = new DeliveryModel();
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            var DeliveryData = db.tblDelivery1.Where(p => p.DeliveryID == DeliveryID).FirstOrDefault();
            if (DeliveryData != null)
            {
                model.DeliveryID = DeliveryData.DeliveryID;
                model.CustomerID = DeliveryData.CustomerID;
                model.PersonName = DeliveryData.PersonName;
                model.Address = DeliveryData.Address;
                model.City = DeliveryData.City;
                model.Landmark = DeliveryData.Landmark;
                model.Pincode = DeliveryData.Pincode;
                model.Type = DeliveryData.Type;

            };
            return model;
        }
    }
}