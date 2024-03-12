using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_college
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddCollege()
        {
            String college = Convert.ToString(dataContext.AddCollege(_universityCode, _collegeName, _recordedBy));
            return college;
        }
        // Get all college
        public TBL_college[] GetAllCollege()
        {
            var college = from col in dataContext.TBL_colleges
                          select col;
            return college.ToArray<TBL_college>();
        }
        public String UpdateCollege()
        {
            String college = Convert.ToString(dataContext.UpdateCollege(_collegeCode, _universityCode, _collegeName, _lastModifiedBy, _currentStatus));
            return college;
        }
        // delete college information
        public void DeleteCollege()
        {
            dataContext.DeleteCollege(_collegeCode);
        }
    }
}
