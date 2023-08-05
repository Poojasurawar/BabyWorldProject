using BabyWorldProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabyWorldProject.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public string SaveCategory(CategoryModel model) 
        {
            string msg = "Save Successfully";
            BabyWorldProjectEntities db = new BabyWorldProjectEntities();
            if (model.CategoryID==0) 
            {
                var CategoryData = new tblCategory()
                {
                    CategoryID = model.CategoryID,
                    Name = model.Name,
                    Details = model.Details,
                };
                db.tblCategories.Add(CategoryData);
                db.SaveChanges();

            }
            else
            {
                var CategoryData = db.tblCategories.Where(p => p.CategoryID == model.CategoryID).FirstOrDefault();
                if (CategoryData != null)
                {
                    CategoryData.CategoryID= model.CategoryID;
                    CategoryData.Name= model.Name;
                    CategoryData.Details = model.Details;
                };
                db.SaveChanges();
                msg = "Updated successfully";
            }
            return msg;
        }

        public List<CategoryModel> GetCategoriesList()
        {
            BabyWorldProjectEntities db= new BabyWorldProjectEntities();
            List<CategoryModel>lstCategory= new List<CategoryModel>();

            var CategoryData = db.tblCategories.ToList();
            if (CategoryData != null)
            {
                foreach (var category in CategoryData)
                {
                    lstCategory.Add(new CategoryModel()
                    {
                        CategoryID = category.CategoryID,
                        Name = category.Name,
                        Details = category.Details,
                    });
                }
            }
            return lstCategory;
        }

       public string DeleteCategory(int CategoryID)
        {
            string msg = "";
            BabyWorldProjectEntities db=new BabyWorldProjectEntities();
            var Categorydata = db.tblCategories.Where(p => p.CategoryID == CategoryID).FirstOrDefault();
            if(Categorydata != null)
            {
                db.tblCategories.Remove(Categorydata);
            }
            db.SaveChanges();
            msg = "Category Deleted Successfully";
            return msg;
        }
        public CategoryModel EditCategory(int CategoryID)
        {
            CategoryModel model= new CategoryModel();
            BabyWorldProjectEntities db=new BabyWorldProjectEntities();
            var CategoryData=db.tblCategories.Where(p=>p.CategoryID == CategoryID).FirstOrDefault();
            if(CategoryData != null)
            {
                model.CategoryID=CategoryData.CategoryID;
                model.Name=CategoryData.Name;
                model.Details=CategoryData.Details;

            };
            return model;
        }
    }
}