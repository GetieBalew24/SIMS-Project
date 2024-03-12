using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_academicQualification
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddAcademicQualification()
        {
            String academicQualification = Convert.ToString(dataContext.AddAcademicQualification(_academicQualificationName, _recordedBy));
            return academicQualification;
        }
        // Get all academicQualification
        public TBL_academicQualification[] GetAllAcademicQualification()
        {
            var academicQualification = from univ in dataContext.TBL_academicQualifications
                                        select univ;
            return academicQualification.ToArray<TBL_academicQualification>();
        }
        public String UpdateAcademicQualification()
        {
            String academicQualification = Convert.ToString(dataContext.UpdateAcademicQualification(_academicQualificationCode, _academicQualificationName, _lastModifiedBy, _currentStatus));
            return academicQualification;
        }
        // delete academicQualification information
        public void DeleteAcademicQualification()
        {
            dataContext.DeleteAcademicQualification(_academicQualificationCode);
        }

    }
}
