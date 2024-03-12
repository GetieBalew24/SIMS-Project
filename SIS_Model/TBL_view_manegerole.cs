using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_view_manegerole
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public TBL_view_manegerole[] GetManageRole1()
        {
            var role = from ro in dataContext.TBL_view_manegeroles
                       where ro.username == _username
                       select ro;
            return role.ToArray<TBL_view_manegerole>();
        }
    }
}
