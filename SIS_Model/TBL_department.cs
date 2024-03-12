using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_department
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddDepartment()
        {
            String department = Convert.ToString(dataContext.AddDepartment(_collegeCode, _departmentName, _recordedBy));
            return department;
        }
        // Get all department
        public TBL_department[] GetAllDepartment()
        {
            var department = from col in dataContext.TBL_departments
                             select col;
            return department.ToArray<TBL_department>();
        }
        public String UpdateDepartment()
        {
            String department = Convert.ToString(dataContext.UpdateDepartment(_departmentCode, _collegeCode, _departmentName, _lastModifiedBy, _currentStatus));
            return department;
        }
        // delete department information
        public void DeleteDepartment()
        {
            dataContext.DeleteDepartment(_departmentCode);
        }
    }
}
