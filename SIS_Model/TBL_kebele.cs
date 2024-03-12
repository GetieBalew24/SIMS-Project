using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_kebele
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddKebele()
        {
            String kebele = Convert.ToString(dataContext.AddKebele(_woredaCode, _kebeleName, _recordedBy));
            return kebele;
        }
        // Get all kebele
        public TBL_kebele[] GetAllKebele()
        {
            var kebele = from univ in dataContext.TBL_kebeles
                         select univ;
            return kebele.ToArray<TBL_kebele>();
        }
        // delete kebele information
        public void DeleteKebele()
        {
            dataContext.DeleteKebele(_kebeleCode);
        }
    }
}
