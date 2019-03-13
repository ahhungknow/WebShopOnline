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
        public IEnumerable<Product> GetProductList(string searchString=null)
        {
            if(String.IsNullOrEmpty(searchString))
            {
                return Db.Product.OrderBy(x=>x.Id);
            }
            else
            {
                return Db.Product.Where(x => x.Id.ToString().Contains(searchString) || x.Name.Contains(searchString)).OrderBy(x=>x.Id);
            }
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
        public Product GetById(int id)
        {
            return Db.Product.Find(id);
        }
        public bool EditProduct(Product product)
        {
            try
            {
                Product item = Db.Product.Find(product.Id);
                item.MetaTitle = product.MetaTitle;
                item.Image = product.Image;
                item.Name = product.Name;
                item.Price = product.Price;
                item.Quantity = product.Quantity;
                item.Sale = product.Sale;
                item.Status = product.Status;
                item.Waranty = product.Waranty;
                item.MoreImage = product.MoreImage;
                item.CategoryId = product.CategoryId;
                item.Code = product.Code;
                item.Description = product.Description;
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                Product product = Db.Product.Find(id);
                Db.Product.Remove(product);
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
