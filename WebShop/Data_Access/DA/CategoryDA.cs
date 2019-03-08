using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DA
{
    public class CategoryDA
    {
        private WebModelDbContext Db;
        private static CategoryDA _Instance;
        public static CategoryDA Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CategoryDA();
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }
        public CategoryDA()
        {
            Db = new WebModelDbContext();
        }
        public IEnumerable<ProductCategory> GetCategoryList()
        {
            return Db.ProductCategory.OrderByDescending(x=>x.DisplayOrder);
        }
        public bool InsertCategory(ProductCategory productCategory)
        {
            try
            {
                Db.ProductCategory.Add(productCategory);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ProductCategory GetById(int Id)
        {
            return Db.ProductCategory.Find(Id);
        }
        public bool UpdateCategory(ProductCategory productCategory)
        {
            try
            {
                var item=Db.ProductCategory.Find(productCategory.Id);
                item.Name = productCategory.Name;
                item.MetaTitle = productCategory.MetaTitle;
                item.SeoTitle = productCategory.SeoTitle;
                item.ParentId = productCategory.ParentId;
                item.DisplayOrder = productCategory.DisplayOrder;
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCategory(int Id)
        {
            try
            {
                ProductCategory productCategory = Db.ProductCategory.Find(Id);
                Db.ProductCategory.Remove(productCategory);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
