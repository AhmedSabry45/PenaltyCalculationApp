using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Data
{
    public interface ICountryRepository
    {
        IEnumerable<Country> AllCountries();
        Country GetCountryById(int countryId);
    }
}
