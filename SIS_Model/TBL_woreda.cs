using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_woreda
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddWoreda()
        {
            String woreda = Convert.ToString(dataContext.AddWoreda(_zoneCode, _woredaName, _recordedBy));
            return woreda;
        }
        // Get all woreda
        public TBL_woreda[] GetAllWoreda()
        {
            var woreda = from univ in dataContext.TBL_woredas
                         select univ;
            return woreda.ToArray<TBL_woreda>();
        }
        // delete woreda information
        public void DeleteWoreda()
        {
            dataContext.DeleteWoreda(_woredaCode);
        }
    }
}
