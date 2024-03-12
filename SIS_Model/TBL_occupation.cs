using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_occupation
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddOccupation()
        {
            String occupation = Convert.ToString(dataContext.AddOccupation(_occupationName, _recordedBy));
            return occupation;
        }
        // Get all occupation
        public TBL_occupation[] GetAllOccupation()
        {
            var occupation = from univ in dataContext.TBL_occupations
                             select univ;
            return occupation.ToArray<TBL_occupation>();
        }
        // delete occupation information
        public void DeleteOccupation()
        {
            dataContext.DeleteOccupation(_occupationCode);
        }
    }
}
