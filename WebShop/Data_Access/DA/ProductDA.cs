using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DA
{
    public class ProductDA
    {
        private WebModelDbContext Db;
        private static ProductDA _Instance;
        public static ProductDA Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ProductDA();
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }
        public ProductDA()
        {
            Db = new WebModelDbContext();
        }
        public IEnumerable<Product> GetProductList(string search=null)
        {
            return Db.Product;
        }
        public bool InsertProduct(Product product)
        {
            try
            {
                Db.Product.Add(product);
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
