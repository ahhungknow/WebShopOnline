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
        public List<ProductCategory> GetCategoryList()
        {
            return Db.ProductCategory.ToList();
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
    }
}
