using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_menu
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddMenu()
        {
            String menu = Convert.ToString(dataContext.AddMenu(_parentCode, _menuName, _menuLink, _recordedBy));
            return menu;
        }
        // Get all menu
        public TBL_menu[] GetAllMenu()
        {
            var menu = from univ in dataContext.TBL_menus
                       select univ;
            return menu.ToArray<TBL_menu>();
        }
        public String UpdateMenu()
        {
            String menu = Convert.ToString(dataContext.UpdateMenu(_menuCode, _parentCode, _menuName, menuLink, _lastModifiedBy, _currentStatus));
            return menu;
        }
        // delete menu information
        public void DeleteMenu()
        {
            dataContext.DeleteMenu(_menuCode);
        }
    }
}
