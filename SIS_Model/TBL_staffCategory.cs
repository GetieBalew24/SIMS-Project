using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_staffCategory
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddStaffCategory()
        {
            String staffCategory = Convert.ToString(dataContext.AddStaffCategory(_staffCategoryName, _recordedBy));
            return staffCategory;
        }
        // Get all staffCategory
        public TBL_staffCategory[] GetAllStaffCategory()
        {
            var staffCategory = from univ in dataContext.TBL_staffCategories
                                select univ;
            return staffCategory.ToArray<TBL_staffCategory>();
        }
        public String UpdateStaffCategory()
        {
            String staffCategory = Convert.ToString(dataContext.UpdateStaffCategory(_staffCategoryCode, _staffCategoryName, _lastModifiedBy, _currentStatus));
            return staffCategory;
        }
        // delete staffCategory information
        public void DeleteStaffCategory()
        {
            dataContext.DeleteStaffCategory(_staffCategoryCode);
        }
    }
}
