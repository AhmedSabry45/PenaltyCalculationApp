using PenaltyCalculation.Web.Models;
using System.Globalization;
using System;
using PenaltyCalculation.Web.Services.Abstract;
using System.Linq;

namespace PenaltyCalculation.Web.Services.Concrete
{
    public class KoreaPenaltyCalculationService:IPenaltyCalculationService
    {
        private readonly decimal PenaltyForEachDayPrice = 1925.56m;
        private readonly int PenaltyDaysLimit = 1;

        public dynamic Calculate(int days, string currency)
        {
            var TotalPrice = days > PenaltyDaysLimit ? (days - PenaltyDaysLimit) * PenaltyForEachDayPrice : 0;

            var CurrencySymbol = new RegionInfo(currency).CurrencySymbol.ToString();

            return new { TotalPrice = TotalPrice, Currency = CurrencySymbol };
        }

        public int GetBusinessDays(PenaltyInputModel inputModel)
        {
            int TotalBusinessDays = 0;

            var holidays = inputModel.Country.Holidays.Select(s => s.Date);

            var dayDifference = (int)inputModel.To.Subtract(inputModel.From).TotalDays;

            for (var date = inputModel.From; date <= inputModel.To; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Friday
                    && date.DayOfWeek != DayOfWeek.Saturday
                    && !holidays.Contains(date))
                    TotalBusinessDays++;
            }

            return TotalBusinessDays;
        }
    }
}
