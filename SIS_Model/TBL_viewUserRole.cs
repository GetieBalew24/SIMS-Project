using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_viewUserRole
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
       
        public TBL_viewUserRole[] GetManageRole2()
        {
            var role = from ro in dataContext.TBL_viewUserRoles
                       where ro.username == _username
                       select ro;
            return role.ToArray<TBL_viewUserRole>();
        }
    }
}
