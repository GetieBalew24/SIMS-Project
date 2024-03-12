using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_highSchool
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddHighSchool()
        {
            String highSchool = Convert.ToString(dataContext.AddHighSchool(_woredaCode, _highSchoolName, _recordedBy));
            return highSchool;
        }
        // Get all highSchool
        public TBL_highSchool[] GetAllHighSchool()
        {
            var highSchool = from univ in dataContext.TBL_highSchools
                         select univ;
            return highSchool.ToArray<TBL_highSchool>();
        }
        // delete highSchool information
        public void DeleteHighSchool()
        {
            dataContext.DeleteHighSchool(_highSchoolCode);
        }
    }
}
