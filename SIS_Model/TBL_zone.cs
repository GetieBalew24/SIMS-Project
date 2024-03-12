using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_zone
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddZone()
        {
            String zone = Convert.ToString(dataContext.AddZone(_regionCode, _zoneName, _recordedBy));
            return zone;
        }
        // Get all zone
        public TBL_zone[] GetAllZone()
        {
            var zone = from univ in dataContext.TBL_zones
                         select univ;
            return zone.ToArray<TBL_zone>();
        }
        // delete zone information
        public void DeleteZone()
        {
            dataContext.DeleteZone(_zoneCode);
        }
    }
}
