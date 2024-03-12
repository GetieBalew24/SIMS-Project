using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_staffDepartment
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddStaffDepartment()
        {
            String staffDept = Convert.ToString(dataContext.AddStaffDepartment(_staffId, _departmentCode, _positionCode, _recordedBy));
            return staffDept;
        }
        public TBL_staffDepartment[] GetAllStaffDepartment()
        {
            var staffDept = from staff in dataContext.TBL_staffDepartments
                            select staff;
            return staffDept.ToArray<TBL_staffDepartment>();
        }
        public String UpdateStaffDepartment()
        {
            String staffDept = Convert.ToString(dataContext.UpdateStaffDepartment(_staffDepartmentCode, _departmentCode, _positionCode, _lastModifiedBy, _currentStatus));
            return staffDept;
        }
        public void DeleteStaffDepartment()
        {
            dataContext.DeleteStaffDepartment(_staffDepartmentCode);
        }
    }
}
