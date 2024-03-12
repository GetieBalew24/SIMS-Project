using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_university
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddUniversity()
        {
            String university = Convert.ToString(dataContext.AddUniversity(_universityName, _recordedBy));
            return university;
        }
        // Get all university
        public TBL_university[] GetAllUnivrsity()
        {
            var university = from univ in dataContext.TBL_universities
                             select univ;
            return university.ToArray<TBL_university>();
        }
        public String UpdateUniversity()
        {
            String university = Convert.ToString(dataContext.UpdateUniversity(_universityCode, _universityName, _lastModifiedBy, _currentStatus));
            return university;
        }
        // delete university information
        public void DeleteUniversity()
        {
            dataContext.DeleteUniversity(_universityCode);
        }
    }
}
