using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_notHaveAccount
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public TBL_notHaveAccount[] GetNotHaveStaffAccount()
        {
            var notStaff = from nsa in dataContext.TBL_notHaveAccounts
                           select nsa;
            return notStaff.ToArray<TBL_notHaveAccount>();
        }
    }
}
