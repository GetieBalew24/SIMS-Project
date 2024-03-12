using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial  class TBL_program
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddProgram()
        {
            String program = Convert.ToString(dataContext.AddProgram(_programName, _recordedBy));
            return program;
        }
        // Get all program
        public TBL_program[] GetAllProgram()
        {
            var program = from univ in dataContext.TBL_programs
                           select univ;
            return program.ToArray<TBL_program>();
        }
        public String UpdateProgram()
        {
            String program = Convert.ToString(dataContext.UpdateProgram(_programCode, _programName, _lastModifiedBy, _currentStatus));
            return program;
        }
        // delete program information
        public void DeleteProgram()
        {
            dataContext.DeleteProgram(_programCode);
        }
    }
}
