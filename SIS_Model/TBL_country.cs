using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Model
{
    public partial class TBL_country
    {
        private readonly SISDBDataContext dataContext = new SISDBDataContext("Data Source=GECH;Initial Catalog=SIS;Integrated Security=True");
        public String AddCountry()
        {
            String country = Convert.ToString(dataContext.AddCountry(_countryName, _continent, _nationality, _recordedBy));
            return country;
        }
        // Get all country
        public TBL_country[] GetAllCountry()
        {
            var country = from univ in dataContext.TBL_countries
                             select univ;
            return country.ToArray<TBL_country>();
        } 
        // delete country information
        public void DeleteCountry()
        {
            dataContext.DeleteCountry(_countryCode);
        }
    }
}
