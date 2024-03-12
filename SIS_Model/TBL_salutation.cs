using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_salutation
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddSalutation()
        {
            String salutation = Convert.ToString(dataContext.AddSalutation(_salutationName, _recordedBy));
            return salutation;
        }
        // Get all salutation
        public TBL_salutation[] GetAllSalutation()
        {
            var salutation = from univ in dataContext.TBL_salutations
                             select univ;
            return salutation.ToArray<TBL_salutation>();
        }
        public String UpdateSalutation()
        {
            String salutation = Convert.ToString(dataContext.UpdateSalutation(_salutationCode, _salutationName, _lastModifiedBy, _currentStatus));
            return salutation;
        }
        // delete salutation information
        public void DeleteSalutation()
        {
            dataContext.DeleteSalutation(_salutationCode);
        }

    }
}
