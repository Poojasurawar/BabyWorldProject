using BabyWorldProject.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;

namespace BabyWorldProject.Models
{
    public class CutomerModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public string SaveCustomer(CutomerModel model) 
        {
            string msg = "Save Successfully";
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            if (model.CustomerID == 0)
            {
                var CustomerData = new tblCustomer()
                {
                    CustomerID = model.CustomerID,
                    Name = model.Name,
                    MobileNo = model.MobileNo,
                    EmailId = model.EmailId,
                    Password = model.Password,
                };
                db.tblCustomers.Add(CustomerData);
                db.SaveChanges();
            }
            else
            {
                var CustomerData=db.tblCustomers.Where(p=>p.CustomerID== CustomerID).FirstOrDefault();
                if (CustomerData != null)
                {
                    CustomerData.CustomerID = model.CustomerID;
                    CustomerData.Name = model.Name;
                    CustomerData.MobileNo = model.MobileNo;
                    CustomerData.EmailId = model.EmailId;
                    CustomerData.Password = model.Password;
                }
                db.SaveChanges();
                msg = "Data updated successfully";
            }
            
            return msg;
        }
        public List<CutomerModel> GetCustomerList()
        {
            BabyWorldProjectEntities db=new BabyWorldProjectEntities();
            List<CutomerModel>lstCustomer= new List<CutomerModel>();
            var CustomerData = db.tblCustomers.ToList();
            if (CustomerData != null)
            {
                foreach (var Customer in CustomerData)
                {
                    lstCustomer.Add(new CutomerModel()
                    {
                        CustomerID = Customer.CustomerID,
                        Name = Customer.Name,
                        MobileNo = Customer.MobileNo,
                        EmailId = Customer.EmailId,
                        Password = Customer.Password,

                    });
                }
            }
            return lstCustomer;
        }

        public string DeleteCustomer(int CustomerID)
        {
            string msg = "";
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            var CustomerData = db.tblCustomers.Where(p => p.CustomerID == CustomerID).FirstOrDefault();
            if(CustomerData != null)
            {
                db.tblCustomers.Remove(CustomerData);
            }
            db.SaveChanges();
            msg = "Customer data deleted";
            return msg;
        }

        public CutomerModel EditCustomer(int CustomerID)
        {
            CutomerModel model= new CutomerModel();
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            var CustomerData = db.tblCustomers.Where(p=>p.CustomerID== CustomerID).FirstOrDefault();
            if(CustomerData != null)
            {
                model.CustomerID = CustomerData.CustomerID;
                model.Name = CustomerData.Name;
                model.MobileNo = CustomerData.MobileNo;
                model.EmailId = CustomerData.EmailId;
                model.Password = CustomerData.Password;
            };
            return model;
        }
    }
}