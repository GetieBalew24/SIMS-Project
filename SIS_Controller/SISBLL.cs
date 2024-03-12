using SIS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Controller
{
    public class SISBLL
    {
        private readonly TBL_university university = new TBL_university();
        private readonly TBL_college college = new TBL_college();
        private readonly TBL_department department = new TBL_department();
        private readonly TBL_system system = new TBL_system();
        private readonly TBL_academicRank academicRank = new TBL_academicRank();
        private readonly TBL_academicQualification academicQualification = new TBL_academicQualification();
        private readonly TBL_salutation salutation = new TBL_salutation();
        private readonly TBL_staffCategory staffCategory = new TBL_staffCategory();
        private readonly TBL_staff staff = new TBL_staff();
        private readonly TBL_position position = new TBL_position();
        private readonly TBL_staffDepartment staffDepartment = new TBL_staffDepartment();
        private readonly TBL_userAccount userAccount = new TBL_userAccount();
        private readonly TBL_role role = new TBL_role();
        private readonly TBL_menu menu = new TBL_menu();
        private readonly TBL_userRole userRole = new TBL_userRole();
        private readonly TBL_positionRole positionRole = new TBL_positionRole();
        private readonly TBL_roleMenu roleMenu = new TBL_roleMenu();
        private readonly TBL_program program = new TBL_program();
        private readonly TBL_admissionClassification admissionClassification = new TBL_admissionClassification();
        private readonly TBL_haveAccount haveStaffAccount = new TBL_haveAccount();
        private readonly TBL_notHaveAccount notHaveStaffAccount = new TBL_notHaveAccount();
        private readonly TBL_viewUserRole viewUserRole = new TBL_viewUserRole();
        private readonly TBL_view_manegerole viewmanagerole = new TBL_view_manegerole();
        private readonly TBL_country country = new TBL_country();
        private readonly TBL_region region = new TBL_region();
        private readonly TBL_zone zone = new TBL_zone();
        private readonly TBL_woreda woreda = new TBL_woreda();
        private readonly TBL_kebele kebele = new TBL_kebele();
        private readonly TBL_highSchool highSchool = new TBL_highSchool();
        private readonly TBL_religion religion = new TBL_religion();
        private readonly TBL_ethinic ethinic = new TBL_ethinic();
        private readonly TBL_occupation occupation = new TBL_occupation();

        // role
        public TBL_view_manegerole[] GetViewManageRole(String username)
        {
            viewmanagerole.username = username;
            return viewmanagerole.GetManageRole1();
        }
        public TBL_viewUserRole[] GetViewUserRole(String username)
        {
            viewUserRole.username = username;
            return viewUserRole.GetManageRole2();
        }
        // staff account
        public TBL_haveAccount[] GetHaveStaffAccounts()
        {
            return haveStaffAccount.GetHaveStaffAccount();
        }
        public TBL_notHaveAccount[] GetNotHaveStaffAccounts()
        {
            return notHaveStaffAccount.GetNotHaveStaffAccount();
        }
        public TBL_userAccount[] Logins(String username, String password)
        {
            userAccount.username = username;
            userAccount.userPassword = password;
            return userAccount.Login();
        }

        public bool AddUserAccounts(String username, String userCategory, String recordedBy)
        {
            try
            {
                userAccount.username = username;
                userAccount.userCategory = userCategory;
                userAccount.recordedBy = recordedBy;
                userAccount.AddUserAccount();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // university Information
        public bool AddUniversities(String universityName, String recordedBy)
        {
            try
            {
                university.universityName = universityName;
                university.recordedBy = recordedBy;
                university.AddUniversity();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_university[] GetAllUniversities()
        {
            return university.GetAllUnivrsity();
        }
        public bool UpdateUniversities(String universityCode, String universityName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                university.universityCode = universityCode;
                university.universityName = universityName;
                university.lastModifiedBy = lastModifiedBy;
                university.currentStatus = currentStatus;
                university.UpdateUniversity();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteUniversities(String universityCode)
        {
            try
            {
                university.universityCode = universityCode;
                university.DeleteUniversity();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // system Information
        public bool AddSystems(String systemName, String recordedBy)
        {
            try
            {
                system.systemName = systemName;
                system.recordedBy = recordedBy;
                system.AddSystem();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_system[] GetAllSystems()
        {
            return system.GetAllSystem();
        }
        public bool UpdateSystems(String systemCode, String systemName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                system.systemCode = systemCode;
                system.systemName = systemName;
                system.lastModifiedBy = lastModifiedBy;
                system.currentStatus = currentStatus;
                system.UpdateSystem();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteSystems(String systemCode)
        {
            try
            {
                system.systemCode = systemCode;
                system.DeleteSystem();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // college Information
        public bool AddColleges(String universityCode, String collegeName, String recordedBy)
        {
            try
            {
                college.universityCode = universityCode;
                college.collegeName = collegeName;
                college.recordedBy = recordedBy;
                college.AddCollege();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_college[] GetAllColleges()
        {
            return college.GetAllCollege();
        }
        public bool UpdateColleges(String collegeCode, String universityCode, String collegeName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                college.universityCode = universityCode;
                college.collegeCode = collegeCode;
                college.collegeName = collegeName;
                college.lastModifiedBy = lastModifiedBy;
                college.currentStatus = currentStatus;
                college.UpdateCollege();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteColleges(String collegeCode)
        {
            try
            {
                college.collegeCode = collegeCode;
                college.DeleteCollege();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        // department Information
        public bool AddDepartments(String collegeCode, String departmentName, String recordedBy)
        {
            try
            {
                department.collegeCode = collegeCode;
                department.departmentName = departmentName;
                department.recordedBy = recordedBy;
                department.AddDepartment();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_department[] GetAllDepartments()
        {
            return department.GetAllDepartment();
        }
        public bool UpdateDepartments(String departmentCode, String collegeCode, String departmentName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                department.collegeCode = collegeCode;
                department.departmentCode = departmentCode;
                department.departmentName = departmentName;
                department.lastModifiedBy = lastModifiedBy;
                department.currentStatus = currentStatus;
                department.UpdateDepartment();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteDepartments(String departmentCode)
        {
            try
            {
                department.departmentCode = departmentCode;
                department.DeleteDepartment();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // AcademicQualification Information
        public bool AddAcademicQualifications(String academicQualificationName, String recordedBy)
        {
            try
            {
                academicQualification.academicQualificationName = academicQualificationName;
                academicQualification.recordedBy = recordedBy;
                academicQualification.AddAcademicQualification();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_academicQualification[] GetAllAcademicQualifications()
        {
            return academicQualification.GetAllAcademicQualification();
        }
        public bool UpdateAcademicQualifications(String academicQualificationCode, String academicQualificationName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                academicQualification.academicQualificationCode = academicQualificationCode;
                academicQualification.academicQualificationName = academicQualificationName;
                academicQualification.lastModifiedBy = lastModifiedBy;
                academicQualification.currentStatus = currentStatus;
                academicQualification.UpdateAcademicQualification();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteAcademicQualifications(String academicQualificationCode)
        {
            try
            {
                academicQualification.academicQualificationCode = academicQualificationCode;
                academicQualification.DeleteAcademicQualification();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // AcademicRank Information
        public bool AddAcademicRanks(String academicRankName, String recordedBy)
        {
            try
            {
                academicRank.academicRankName = academicRankName;
                academicRank.recordedBy = recordedBy;
                academicRank.AddAcademicRank();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_academicRank[] GetAllAcAdemicRanks()
        {
            return academicRank.GetAllAcademicRank();
        }
        public bool UpdateAcademicRanks(String academicRankCode, String academicRankName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                academicRank.academicRankCode = academicRankCode;
                academicRank.academicRankName = academicRankName;
                academicRank.lastModifiedBy = lastModifiedBy;
                academicRank.currentStatus = currentStatus;
                academicRank.UpdateAcademicRank();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteAcademicRanks(String academicRankCode)
        {
            try
            {
                academicRank.academicRankCode = academicRankCode;
                academicRank.DeleteAcademicRank();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Salutation Information
        public bool AddSalutations(String salutationName, String recordedBy)
        {
            try
            {
                salutation.salutationName = salutationName;
                salutation.recordedBy = recordedBy;
                salutation.AddSalutation();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_salutation[] GetAllSalutations()
        {
            return salutation.GetAllSalutation();
        }
        public bool UpdateSalutations(String salutationCode, String salutationName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                salutation.salutationCode = salutationCode;
                salutation.salutationName = salutationName;
                salutation.lastModifiedBy = lastModifiedBy;
                salutation.currentStatus = currentStatus;
                salutation.UpdateSalutation();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteSalutations(String salutationCode)
        {
            try
            {
                salutation.salutationCode = salutationCode;
                salutation.DeleteSalutation();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // staffCategory Information
        public bool AddStaffCategories(String staffCategoryName, String recordedBy)
        {
            try
            {
                staffCategory.staffCategoryName = staffCategoryName;
                staffCategory.recordedBy = recordedBy;
                staffCategory.AddStaffCategory();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_staffCategory[] GetAllStaffCategories()
        {
            return staffCategory.GetAllStaffCategory();
        }
        public bool UpdateStaffCategories(String staffCategoryCode, String staffCategoryName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                staffCategory.staffCategoryCode = staffCategoryCode;
                staffCategory.staffCategoryName = staffCategoryName;
                staffCategory.lastModifiedBy = lastModifiedBy;
                staffCategory.currentStatus = currentStatus;
                staffCategory.UpdateStaffCategory();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteStaffCategories(String staffCategoryCode)
        {
            try
            {
                staffCategory.staffCategoryCode = staffCategoryCode;
                staffCategory.DeleteStaffCategory();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // position Information
        public bool AddPositions(String positionName, String recordedBy)
        {
            try
            {
                position.positionName = positionName;
                position.recordedBy = recordedBy;
                position.AddPosition();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_position[] GetAllPositions()
        {
            return position.GetAllPosition();
        }
        public bool UpdatePositions(String positionCode, String positionName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                position.positionCode = positionCode;
                position.positionName = positionName;
                position.lastModifiedBy = lastModifiedBy;
                position.currentStatus = currentStatus;
                position.UpdatePosition();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeletePositions(String positionCode)
        {
            try
            {
                position.positionCode = positionCode;
                position.DeletePosition();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // staff information

        public bool AddStaffs(String salutationCode, String firstName, String fatherName, String grandfatherName, String gender, String phone, String email, String academicRankCode, String academicQualificationcode, String staffcategoryCode, String isExternal, String recordedBy)
        {
            try
            {
                staff.salutationCode = salutationCode;
                staff.firstName = firstName;
                staff.fatherName = fatherName;
                staff.grandFatherName = grandfatherName;
                staff.gender = gender;
                staff.phone = phone;
                staff.email = email;
                staff.academicRankCode = academicRankCode;
                staff.academicQualificationCode = academicQualificationcode;
                staff.staffCategoryCode = staffcategoryCode;
                staff.isExternal = isExternal;
                staff.recordedBy = recordedBy;
                staff.AddStaff();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_staff[] GetStaffs()
        {
            return staff.GetAllStaff();
        }
        public bool UpdateStaffs(String staffId, String salutationCode, String firstName, String fatherName, String grandFatherName, String gender, String phone, String email, String academicrankCode, String academicQualificationCode, String staffCategoryCode, String isExternal, String lastModifiedBy, int currentStatus)
        {
            try
            {
                staff.staffId = staffId;
                staff.salutationCode = salutationCode;
                staff.firstName = firstName;
                staff.fatherName = fatherName;
                staff.grandFatherName = grandFatherName;
                staff.gender = gender;
                staff.phone = phone;
                staff.email = email;
                staff.academicRankCode = academicrankCode;
                staff.academicQualificationCode = academicQualificationCode;
                staff.staffCategoryCode = staffCategoryCode;
                staff.isExternal = isExternal;
                staff.lastModifiedBy = lastModifiedBy;
                staff.currentStatus = currentStatus;
                staff.UpdateStaff();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteStaffs(String staffId)
        {
            try
            {
                staff.staffId = staffId;
                staff.DeleteStaff();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_staff[] FindStaffCodes(String staffId)
        {
            staff.staffId = staffId;
            return staff.FindStaffCode();
        }
        public TBL_staff[] FindStaffNames(String firstName)
        {
            staff.firstName = firstName;
            return staff.FindStaffName();
        }
        // staffDepartment information
        public bool AddStaffDepartments(String staffId, String departmentCode, String positionCode, String recordedBy)
        {
            try
            {
                staffDepartment.staffId = staffId;
                staffDepartment.departmentCode = departmentCode;
                staffDepartment.positionCode = positionCode;
                staffDepartment.recordedBy = recordedBy;
                staffDepartment.AddStaffDepartment();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_staffDepartment[] GetStaffDepartments()
        {
            return staffDepartment.GetAllStaffDepartment();
        }
        public bool UpdateStaffDepartments(String staffDepartmentCode, String departmentCode, String positionCode, String lastModifiedBy, int currentStatus)
        {
            try
            {
                staffDepartment.staffDepartmentCode = staffDepartmentCode;
                staffDepartment.departmentCode = departmentCode;
                staffDepartment.positionCode = positionCode;
                staffDepartment.lastModifiedBy = lastModifiedBy;
                staffDepartment.currentStatus = currentStatus;
                staffDepartment.UpdateStaffDepartment();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteStaffDepartments(String staffDepartmentCode)
        {
            try
            {
                staffDepartment.staffDepartmentCode = staffDepartmentCode;
                staffDepartment.DeleteStaffDepartment();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        // role Information
        public bool AddRoles(String roleName, String recordedBy)
        {
            try
            {
                role.roleName = roleName;
                role.recordedBy = recordedBy;
                role.AddRole();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_role[] GetAllRoles()
        {
            return role.GetAllRole();
        }
        public bool UpdateRoles(String roleCode, String roleName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                role.roleCode = roleCode;
                role.roleName = roleName;
                role.lastModifiedBy = lastModifiedBy;
                role.currentStatus = currentStatus;
                role.UpdateRole();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteRoles(String roleCode)
        {
            try
            {
                role.roleCode = roleCode;
                role.DeleteRole();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_role[] FindRoleCodes(String roleCode)
        {
            role.roleCode = roleCode;
            return role.FindRoleCode();
        }
        // menu Information
        public bool AddMenus(int parentCode, String menuName, String menuLink, String recordedBy)
        {
            try
            {
                menu.parentCode = parentCode;
                menu.menuName = menuName;
                menu.menuLink = menuLink;
                menu.recordedBy = recordedBy;
                menu.AddMenu();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_menu[] GetAllMenus()
        {
            return menu.GetAllMenu();
        }
        public bool UpdateMenus(int menuCode, int parentCode, String menuName, String menuLink, String lastModifiedBy, int currentStatus)
        {
            try
            {
                menu.menuCode = menuCode;
                menu.parentCode = parentCode;
                menu.menuName = menuName;
                menu.menuLink = menuLink;
                menu.lastModifiedBy = lastModifiedBy;
                menu.currentStatus = currentStatus;
                menu.UpdateMenu();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteMenus(int menuCode)
        {
            try
            {
                menu.menuCode = menuCode;
                menu.DeleteMenu();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // userRole Information
        public bool AddUserRoles(String username, String roleCode, String recordedBy)
        {
            try
            {
                userRole.username = username;
                userRole.roleCode = roleCode;
                userRole.recordedBy = recordedBy;
                userRole.AddUserRole();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_userRole[] GetAllUserRoles()
        {
            return userRole.GetAllUserRole();
        }
        public bool DeleteUserRoles(String userRoleCode)
        {
            try
            {
                userRole.userRoleCode = userRoleCode;
                userRole.DeleteUserRole();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_userRole[] FindUserRoleUsernames(String username)
        {
            userRole.username = username;
            return userRole.FindUserRoleUsername();
        }


        // positionRole Information
        public bool AddPositionRoles(String positionCode, String roleCode, String recordedBy)
        {
            try
            {
                positionRole.positionCode = positionCode;
                positionRole.roleCode = roleCode;
                positionRole.recordedBy = recordedBy;
                positionRole.AddPositionRole();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_positionRole[] GetAllPositionRoles()
        {
            return positionRole.GetAllPositionRole();
        }
        public bool DeletePositionRoles(String positionRoleCode)
        {
            try
            {
                positionRole.positionRoleCode = positionRoleCode;
                positionRole.DeletePositionRole();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // roleMenu Information
        public bool AddRoleMenus(String roleCode, int menuCode, String recordedBy)
        {
            try
            {
                roleMenu.roleCode = roleCode;
                roleMenu.menuCode = menuCode;
                roleMenu.recordedBy = recordedBy;
                roleMenu.AddRoleMenu();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_roleMenu[] GetAllRoleMenus()
        {
            return roleMenu.GetAllRoleMenu();
        }
        public bool DeleteRoleMenus(String roleMenuCode)
        {
            try
            {
                roleMenu.roleMenuCode = roleMenuCode;
                roleMenu.DeleteRoleMenu();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // program Information
        public bool AddPrograms(String programName, String recordedBy)
        {
            try
            {
                program.programName = programName;
                program.recordedBy = recordedBy;
                program.AddProgram();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_program[] GetAllPrograms()
        {
            return program.GetAllProgram();
        }
        public bool UpdatePrograms(String programCode, String programName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                program.programCode = programCode;
                program.programName = programName;
                program.lastModifiedBy = lastModifiedBy;
                program.currentStatus = currentStatus;
                program.UpdateProgram();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeletePrograms(String programCode)
        {
            try
            {
                program.programCode = programCode;
                program.DeleteProgram();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        // admissioncalssification Information
        public bool AddAdmissionClassifications(String admissionClassificationName, String recordedBy)
        {
            try
            {
                admissionClassification.admissionClassificationName = admissionClassificationName;
                admissionClassification.recordedBy = recordedBy;
                admissionClassification.AddAdmissionClassification();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_admissionClassification[] GetAllAdmissionClassifications()
        {
            return admissionClassification.GetAllAdmissionClassification();
        }
        public bool UpdateAdmissionClassifications(String admissionClassificationCode, String admissionClassificationName, String lastModifiedBy, int currentStatus)
        {
            try
            {
                admissionClassification.admissionClassificationCode = admissionClassificationCode;
                admissionClassification.admissionClassificationName = admissionClassificationName;
                admissionClassification.lastModifiedBy = lastModifiedBy;
                admissionClassification.currentStatus = currentStatus;
                admissionClassification.UpdateAdmissionClassification();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteAdmissionClassifications(String admissionClassificationCode)
        {
            try
            {
                admissionClassification.admissionClassificationCode = admissionClassificationCode;
                admissionClassification.DeleteAdmissionClassification();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // country

        public bool AddCountrys(String countryName, String continent, String nationality, String recordedBy)
        {
            try
            {
                country.countryName = countryName;
                country.continent = continent;
                country.nationality = nationality;
                country.recordedBy = recordedBy;
                country.AddCountry();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_country[] GetAllCountrys()
        {
            return country.GetAllCountry();
        }
         
        public bool DeleteCountrys(String countryCode)
        {
            try
            {
                country.countryCode = countryCode;
                country.DeleteCountry();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // region

        public bool AddRegions(String countryCode, String regionName, String regionNo, String recordedBy)
        {
            try
            {
                region.countryCode = countryCode;
                region.regionName = regionName;
                region.regionNo = regionNo;
                region.recordedBy = recordedBy;
                region.AddRegion();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_region[] GetAllRegions()
        {
            return region.GetAllRegion();
        }

        public bool DeleteRegions(String regionCode)
        {
            try
            {
                region.regionCode = regionCode;
                region.DeleteRegion();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // zone

        public bool AddZones(String regionCode, String zoneName, String recordedBy)
        {
            try
            {
                zone.regionCode = regionCode;
                zone.zoneName = zoneName; 
                zone.recordedBy = recordedBy;
                zone.AddZone();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_zone[] GetAllZones()
        {
            return zone.GetAllZone();
        }

        public bool DeleteZones(String zoneCode)
        {
            try
            {
                zone.zoneCode = zoneCode;
                zone.DeleteZone();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // woreda

        public bool AddWoredas(String zoneCode, String woredaName, String recordedBy)
        {
            try
            {
                woreda.zoneCode = zoneCode;
                woreda.woredaName = woredaName;
                woreda.recordedBy = recordedBy;
                woreda.AddWoreda();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_woreda[] GetAllWoredas()
        {
            return woreda.GetAllWoreda();
        }

        public bool DeleteWoredas(String woredaCode)
        {
            try
            {
                woreda.woredaCode = woredaCode;
                woreda.DeleteWoreda();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        // highschool

        public bool AddHighSchools(String woredaCode, String highSchoolName, String recordedBy)
        {
            try
            {
                highSchool.woredaCode = woredaCode;
                highSchool.highSchoolName = highSchoolName;
                highSchool.recordedBy = recordedBy;
                highSchool.AddHighSchool();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_highSchool[] GetAllHighSchools()
        {
            return highSchool.GetAllHighSchool();
        }

        public bool DeleteHighSchools(String highSchoolCode)
        {
            try
            {
                highSchool.highSchoolCode = highSchoolCode;
                highSchool.DeleteHighSchool();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // kebele
        public bool AddKebeles(String woredaCode, String kebeleName, String recordedBy)
        {
            try
            {
                kebele.woredaCode = woredaCode;
                kebele.kebeleName = kebeleName;
                kebele.recordedBy = recordedBy;
                kebele.AddKebele();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_kebele[] GetAllKebeles()
        {
            return kebele.GetAllKebele();
        }

        public bool DeleteKebeles(String kebeleCode)
        {
            try
            {
                kebele.kebeleCode = kebeleCode;
                kebele.DeleteKebele();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // religion
        public bool AddReligions(String religionName, String recordedBy)
        {
            try
            {
                religion.religionName = religionName; 
                religion.recordedBy = recordedBy;
                religion.AddReligion();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_religion[] GetAllReligions()
        {
            return religion.GetAllReligion();
        }

        public bool DeleteReligions(String religionCode)
        {
            try
            {
                religion.religionCode = religionCode;
                religion.DeleteReligion();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // kebele
        public bool AddEthinics(String ethinicName, String recordedBy)
        {
            try
            {
                ethinic.ethinicName = ethinicName;
                ethinic.recordedBy = recordedBy;
                ethinic.AddEthinic();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_ethinic[] GetAllEthinics()
        {
            return ethinic.GetAllEthinic();
        }

        public bool DeleteEthinics(String ethinicCode)
        {
            try
            {
                ethinic.ethinicCode = ethinicCode;
                ethinic.DeleteEthinic();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        // occupation
        public bool AddOccupations(String ocupationName, String recordedBy)
        {
            try
            {
                occupation.occupationName = ocupationName;
                occupation.recordedBy = recordedBy;
                occupation.AddOccupation();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public TBL_occupation[] GetAllOccupations()
        {
            return occupation.GetAllOccupation();
        }

        public bool DeleteOccupations(String occupationCode)
        {
            try
            {
                occupation.occupationCode = occupationCode;
                occupation.DeleteOccupation();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
