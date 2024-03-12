using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_academicRank
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddAcademicRank()
        {
            String academicRank = Convert.ToString(dataContext.AddAcademicRank(_academicRankName, _recordedBy));
            return academicRank;
        }
        // Get all academicRank
        public TBL_academicRank[] GetAllAcademicRank()
        {
            var academicRank = from univ in dataContext.TBL_academicRanks
                               select univ;
            return academicRank.ToArray<TBL_academicRank>();
        }
        public String UpdateAcademicRank()
        {
            String academicRank = Convert.ToString(dataContext.UpdateAcademicRank(_academicRankCode, _academicRankName, _lastModifiedBy, _currentStatus));
            return academicRank;
        }
        // delete academicRank information
        public void DeleteAcademicRank()
        {
            dataContext.DeleteAcademicRank(_academicRankCode);
        }
    }
}
