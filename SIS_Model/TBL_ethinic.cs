using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_ethinic
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddEthinic()
        {
            String ethinic = Convert.ToString(dataContext.AddEthinic(_ethinicName, _recordedBy));
            return ethinic;
        }
        // Get all ethinic
        public TBL_ethinic[] GetAllEthinic()
        {
            var ethinic = from univ in dataContext.TBL_ethinics
                             select univ;
            return ethinic.ToArray<TBL_ethinic>();
        }
        // delete ethinic information
        public void DeleteEthinic()
        {
            dataContext.DeleteEthinic(_ethinicCode);
        }
    }
}
