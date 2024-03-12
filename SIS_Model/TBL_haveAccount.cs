using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_haveAccount
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public TBL_haveAccount[] GetHaveStaffAccount()
        {
            var staff = from sa in dataContext.TBL_haveAccounts
                        select sa;
            return staff.ToArray<TBL_haveAccount>();
        }
    }
}
