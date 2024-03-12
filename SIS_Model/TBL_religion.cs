using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_religion
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddReligion()
        {
            String religion = Convert.ToString(dataContext.AddReligion(_religionName, _recordedBy));
            return religion;
        }
        // Get all religion
        public TBL_religion[] GetAllReligion()
        {
            var religion = from univ in dataContext.TBL_religions
                         select univ;
            return religion.ToArray<TBL_religion>();
        }
        // delete religion information
        public void DeleteReligion()
        {
            dataContext.DeleteReligion(_religionCode);
        }
    }
}
