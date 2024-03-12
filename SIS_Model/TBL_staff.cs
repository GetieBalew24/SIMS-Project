using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_staff
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddStaff()
        {
            String staff = Convert.ToString(dataContext.AddStaff(_salutationCode, _firstName, _fatherName, _grandFatherName, _gender, _phone, _email, _academicRankCode, _academicQualificationCode, _staffCategoryCode, _isExternal, _recordedBy));
            return staff;
        }
        // Get all staff
        public TBL_staff[] GetAllStaff()
        {
            var staff = from stf in dataContext.TBL_staffs
                        select stf;
            return staff.ToArray<TBL_staff>();
        }
        // update staff information
        public String UpdateStaff()
        {
            String staff = Convert.ToString(dataContext.UpdateStaff(_staffId, _salutationCode, _firstName, _fatherName, _grandFatherName, _gender, _phone, _email, _academicRankCode, _academicQualificationCode, _staffCategoryCode, _isExternal, _lastModifiedBy, _currentStatus));
            return staff;
        }
        // delete staff information
        public void DeleteStaff()
        {
            dataContext.DeleteStaff(_staffId);
        }
        public TBL_staff[] FindStaffCode()
        {
            var staff = from s in dataContext.TBL_staffs
                       where s.staffId == _staffId
                       select s;
            return staff.ToArray<TBL_staff>();
        }
        public TBL_staff[] FindStaffName()
        {
            var staff = from s in dataContext.TBL_staffs
                        where s.firstName == _firstName
                        select s;
            return staff.ToArray<TBL_staff>();
        }
    }
}
