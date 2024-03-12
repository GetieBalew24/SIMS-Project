using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_userAccount
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddUserAccount()
        {
            String userAccount = Convert.ToString(dataContext.AddUserAccount(_username, _userCategory, _recordedBy));
            return userAccount;
        }
        public TBL_userAccount[] Login()
        {
            var login = from log in dataContext.TBL_userAccounts
                        where log.username == _username && log.userPassword == _userPassword
                        select log;
            return login.ToArray<TBL_userAccount>();
        }
    }
}
