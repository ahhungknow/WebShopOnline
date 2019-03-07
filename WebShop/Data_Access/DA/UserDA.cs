using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DA
{
    public class UserDA
    {
        WebModelDbContext Db { get; set; }
        public UserDA()
        {
            Db = new WebModelDbContext();
        }
        public bool InsertUser(Account account)
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
        public bool Login(Account account)
        {
            if (Db.Account.Where(x => x.Id == account.Id && x.Password == account.Password).Count()>0)
                return true;
            return false;
        }
    }
}
