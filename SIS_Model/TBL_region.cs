using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_region
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddRegion()
        {
            String region = Convert.ToString(dataContext.AddRegion(_countryCode, _regionName, regionNo, _recordedBy));
            return region;
        }
        // Get all region
        public TBL_region[] GetAllRegion()
        {
            var region = from univ in dataContext.TBL_regions
                          select univ;
            return region.ToArray<TBL_region>();
        }
        // delete region information
        public void DeleteRegion()
        {
            dataContext.DeleteRegion(_regionCode);
        }
    }
}
