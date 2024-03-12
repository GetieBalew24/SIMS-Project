using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_system
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");

        public String AddSystem()
        {
            String system = Convert.ToString(dataContext.AddSystem(_systemName, _recordedBy));
            return system;
        }
        public TBL_system[] GetAllSystem()
        {
            var system = from sys in dataContext.TBL_systems
                         select sys;
            return system.ToArray<TBL_system>();
        }
        public String UpdateSystem()
        {
            String system = Convert.ToString(dataContext.UpdateSystem(_systemCode, _systemName, _lastModifiedBy, _currentStatus));
            return system;
        }
        // delete system information
        public void DeleteSystem()
        {
            dataContext.DeleteSystem(_systemCode);
        }
    }
}
