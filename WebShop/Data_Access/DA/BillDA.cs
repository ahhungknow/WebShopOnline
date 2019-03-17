using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DA
{
    public class BillDA
    {
        private WebModelDbContext Db;
        private static BillDA _Instance;
        public static BillDA Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BillDA();
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }

        public BillDA()
        {
            Db = new WebModelDbContext();
        }

        public IEnumerable<Bill> GetListBill(string searchString=null)
        {
            if(String.IsNullOrEmpty(searchString))
            {
                return Db.Bill.OrderBy(x => x.Id);
            }
            else
            {
                return Db.Bill.Where(x => x.Id.ToString().Contains(searchString)).OrderBy(x => x.Id);
            }
        }

        public Bill GetById(int id)
        {
            return Db.Bill.Find(id);
        }

        public bool InsertBill(Bill bill)
        {
            try
            {
                Db.Bill.Add(bill);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditBill(Bill bill)
        {
            try
            {
                Bill item= Db.Bill.Find(bill.Id);
                item.CreateDate = bill.CreateDate;
                item.CustomerId = bill.CustomerId;
                item.ShipAddress = bill.ShipAddress;
                item.Status = bill.Status;
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBill(int id)
        {
            try
            {
                Bill item = Db.Bill.Find(id);
                Db.Bill.Remove(item);
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
