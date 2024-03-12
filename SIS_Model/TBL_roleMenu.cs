using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_roleMenu
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddRoleMenu()
        {
            String roleMenu = Convert.ToString(dataContext.AddRoleMenu(_roleCode,_menuCode, _recordedBy));
            return roleMenu;
        }
        // Get all roleMenu
        public TBL_roleMenu[] GetAllRoleMenu()
        {
            var roleMenu = from rm in dataContext.TBL_roleMenus
                       select rm;
            return roleMenu.ToArray<TBL_roleMenu>();
        } 
        // delete role information
        public void DeleteRoleMenu()
        {
            dataContext.DeleteRoleMenu(_roleMenuCode);
        }
    }
}
