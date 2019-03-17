using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DA
{
    public class BillInfoDA
    {
        private WebModelDbContext Db;
        private static BillInfoDA _Instance;
        public static BillInfoDA Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BillInfoDA();
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }
        public BillInfoDA()
        {
            Db = new WebModelDbContext();
        }

        public IEnumerable<BillInfo> GetBillInfo(string searchString = null)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return Db.BillInfo.OrderBy(x => x.Id);
            }
            else
            {
                return Db.BillInfo.Where(x => x.Id.ToString().Contains(searchString)).OrderBy(x => x.Id);
            }
        }

        public BillInfo GetById(int id)
        {
            return Db.BillInfo.Find(id);
        }

        public bool InsertBillInfo(BillInfo billInfo)
        {
            try
            {
                Db.BillInfo.Add(billInfo);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditBillInfo(BillInfo billInfo)
        {
            try
            {

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
