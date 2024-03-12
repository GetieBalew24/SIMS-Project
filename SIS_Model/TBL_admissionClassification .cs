using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_admissionClassification
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddAdmissionClassification()
        {
            String admissionClassification = Convert.ToString(dataContext.AddAdmissionClassification(_admissionClassificationName, _recordedBy));
            return admissionClassification;
        }
        // Get all admissionClassification
        public TBL_admissionClassification[] GetAllAdmissionClassification()
        {
            var admissionClassification = from univ in dataContext.TBL_admissionClassifications
                               select univ;
            return admissionClassification.ToArray<TBL_admissionClassification>();
        }
        public String UpdateAdmissionClassification()
        {
            String admissionClassification = Convert.ToString(dataContext.UpdateAdmissionClassification(_admissionClassificationCode, _admissionClassificationName, _lastModifiedBy, _currentStatus));
            return admissionClassification;
        }
        // delete admissionClassification information
        public void DeleteAdmissionClassification()
        {
            dataContext.DeleteAdmissionClassification(_admissionClassificationCode);
        }
    }
}
