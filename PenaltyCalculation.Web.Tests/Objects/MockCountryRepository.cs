using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PenaltyCalculation.Web.Data;

namespace PenaltyCalculation.Web.Tests.Objects
{
    public class MockCountryRepository :ICountryRepository
    {

        private IEnumerable<Holiday> HolidaysList => new List<Holiday> {
            new Holiday { HolidayId = 1, Name = "Eid", Date = new DateTime(2022, 11, 1), CountryId = 1 },
            new Holiday { HolidayId = 2, Name = "Eid", Date = new DateTime(2022, 11, 2), CountryId = 1 },
            new Holiday { HolidayId = 3, Name = "Eid", Date = new DateTime(2022, 11, 3), CountryId = 1 },
            
        };

        private  IEnumerable<Country> AllCountriesList => new List<Country> {
            new Country { CountryId = 1, Name = "Turkey", Currency = "TR" ,Holidays=HolidaysList.ToList()},
            new Country { CountryId = 2, Name = "United Arab Emirates", Currency = "AE" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "China", Currency = "TW" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "German", Currency = "DE" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "Denmark", Currency = "DK" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "UnitedState", Currency = "US" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "France", Currency = "FR" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "Italy", Currency = "IT" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "Japan", Currency = "JP" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "Korea", Currency = "KR" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "Russia", Currency = "RU" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "India", Currency = "IN" ,Holidays= new List<Holiday>() },
            new Country { CountryId = 2, Name = "Egypt", Currency = "EG" ,Holidays= new List<Holiday>() },
        };

        public  IEnumerable<Country> AllCountries =>  AllCountriesList;

        public Country GetCountryById(int countryId)
        {
            return AllCountriesList.FirstOrDefault(c => c.CountryId == countryId);
        }
   
    }
}
