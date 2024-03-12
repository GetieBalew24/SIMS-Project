using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_userRole
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddUserRole()
        {
            String userRole = Convert.ToString(dataContext.AddUserRole(_username, _roleCode, _recordedBy));
            return userRole;
        }
        public TBL_userRole[] GetAllUserRole()
        {
            var userRole = from ur in dataContext.TBL_userRoles
                            select ur;
            return userRole.ToArray<TBL_userRole>();
        } 
        public void DeleteUserRole()
        {
            dataContext.DeleteUserRole(_userRoleCode);
        }
        public TBL_userRole[] FindUserRoleUsername()
        {
            var userRole = from s in dataContext.TBL_userRoles
                        where s.username == _username
                        select s;
            return userRole.ToArray<TBL_userRole>();
        }
    }
}
