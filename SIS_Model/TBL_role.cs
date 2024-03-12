using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_role
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddRole()
        {
            String role = Convert.ToString(dataContext.AddRole(_roleName, _recordedBy));
            return role;
        }
        // Get all role
        public TBL_role[] GetAllRole()
        {
            var role = from univ in dataContext.TBL_roles
                       select univ;
            return role.ToArray<TBL_role>();
        }
        public String UpdateRole()
        {
            String role = Convert.ToString(dataContext.UpdateRole(_roleCode, _roleName, _lastModifiedBy, _currentStatus));
            return role;
        }
        // delete role information
        public void DeleteRole()
        {
            dataContext.DeleteRole(_roleCode);
        }
        public TBL_role[] FindRoleCode()
        {
            var role = from s in dataContext.TBL_roles
                        where s.roleCode == _roleCode
                        select s;
            return role.ToArray<TBL_role>();
        }
    }
}
