using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DA
{
    public class AccountDA
    {
        private WebModelDbContext Db;
        private static AccountDA _Instance;
        public static AccountDA Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AccountDA();
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }
        public AccountDA()
        {
            Db = new WebModelDbContext();
        }
        public IEnumerable<Account> GetAccountList(string searchString=null)
        {
            if(String.IsNullOrEmpty(searchString))
            {
                return Db.Account.OrderBy(x => x.Id);
            }
            else
            {
                return Db.Account.Where(x => x.Id.ToString().Contains(searchString) || x.Name.Contains(searchString)).OrderBy(x => x.Id);
            }
        }
        public bool InsertAccount(Account account)
        {
            try
            {          
                Db.Account.Add(account);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Account GetById(string id)
        {
            return Db.Account.Find(id);
        }
        public bool EditAccount(Account account)
        {
            try
            {
                Account item= Db.Account.Find(account.Id);
                item.Password = account.Password;
                item.Name = account.Name;
                item.Phone = account.Phone;
                item.Role = account.Role;
                item.Status = account.Status;
                item.Address = account.Address;
                item.Email = account.Email;
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteAccount(int id)
        {
            try
            {
                Account account = Db.Account.Find(id);
                Db.Account.Remove(account);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Login(Account account)
        {
            if (Db.Account.Where(x => x.Id == account.Id && x.Password == account.Password).Count()>0)
                return true;
            return false;
        }
        public bool ChangeStatus(string id)
        {
            Account account = Db.Account.Find(id);
            account.Status = !account.Status;
            Db.SaveChanges();
            return (bool)account.Status;
        }
    }
}
