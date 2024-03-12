using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_position
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddPosition()
        {
            String position = Convert.ToString(dataContext.AddPosition(_positionName, _recordedBy));
            return position;
        }
        // Get all position
        public TBL_position[] GetAllPosition()
        {
            var position = from univ in dataContext.TBL_positions
                           select univ;
            return position.ToArray<TBL_position>();
        }
        public String UpdatePosition()
        {
            String position = Convert.ToString(dataContext.UpdatePosition(_positionCode, _positionName, _lastModifiedBy, _currentStatus));
            return position;
        }
        // delete position information
        public void DeletePosition()
        {
            dataContext.DeletePosition(_positionCode);
        }
    }
}
