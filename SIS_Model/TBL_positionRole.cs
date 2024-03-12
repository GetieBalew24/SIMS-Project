using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_positionRole
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddPositionRole()
        {
            String positionRole = Convert.ToString(dataContext.AddPositionRole(_positionCode, _roleCode, _recordedBy));
            return positionRole;
        }
        public TBL_positionRole[] GetAllPositionRole()
        {
            var positionRole = from ur in dataContext.TBL_positionRoles
                           select ur;
            return positionRole.ToArray<TBL_positionRole>();
        }
        public void DeletePositionRole()
        {
            dataContext.DeletePositionRole(_positionRoleCode);
        }
    }
}
