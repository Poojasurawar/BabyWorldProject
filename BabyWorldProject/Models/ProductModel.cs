using BabyWorldProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabyWorldProject.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public string MFGDate { get; set; }
        public string ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal IGST { get; set; }
        public int CategoryID { get; set; }

        public string SaveProduct(ProductModel model)
        {
            string msg = "Save Success";
            BabyWorldProjectEntities db= new BabyWorldProjectEntities();

            var ProductData = new tblProduct()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                ProductImage = model.ProductImage,
                Description = model.Description,
                MFGDate = Convert.ToDateTime(model.MFGDate),
                ExpiryDate = Convert.ToDateTime(model.ExpiryDate),
                Price = model.Price,
                Discount = model.Discount,
                SGST = model.SGST,
                CGST = model.CGST,
                IGST = model.IGST,
                CategoryID = model.CategoryID,
            };
            db.tblProducts.Add(ProductData);
            db.SaveChanges();
            return msg;
        }

        public List<ProductModel> GetProductList()
        {
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            List<ProductModel>lstProduct = new List<ProductModel>();
            var Productdata = db.tblProducts.ToList();

            if(Productdata != null )
            {
                foreach( var product in Productdata )
                {
                    lstProduct.Add(new ProductModel
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        ProductImage = product.ProductImage,
                        Description = product.Description,
                        MFGDate = Convert.ToString(product.MFGDate),
                        ExpiryDate = Convert.ToString(product.ExpiryDate),
                        Price = product.Price,
                        Discount = product.Discount,
                        SGST = product.SGST,
                        CGST = product.CGST,
                        IGST = product.IGST,
                        CategoryID = product.CategoryID,

                    });
                }
            }
            return lstProduct;
        }

    public string DeleteProduct(int ProductID)
        {
            string msg = "";
            BabyWorldProjectEntities db= new BabyWorldProjectEntities();
            var ProductData = db.tblProducts.Where(p => p.ProductID == ProductID).FirstOrDefault();
            if( ProductData != null )
            {
                db.tblProducts.Remove(ProductData);
            }
           db.SaveChanges();
            msg = "Product Deleted Successfully";
            return msg;
        }


    }
}