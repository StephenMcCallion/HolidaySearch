using HolidaySearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class HolidaySearch : IHolidaySearch
    {
        public IEnumerable<IFlight> _flights { get; set; }
        public HolidaySearch(IEnumerable<IFlight> flights)
        {
            this._flights = flights;
        }

        /// <summary>
        /// Method that searches for a flight
        /// </summary>
        /// <param name="departingFrom">Depature Airport</param>
        /// <param name="arrivingTo">Arrival Airport</param>
        /// <param name="departureDate">Date of Departure</param>
        /// <returns></returns>
        public IEnumerable<IFlight> SearchForFlights(string departingFrom, string arrivingTo, DateTime departureDate)
        {
            return _flights.Where(f =>
                f.from.Equals(departingFrom, StringComparison.OrdinalIgnoreCase) &&
                f.to.Equals(arrivingTo, StringComparison.OrdinalIgnoreCase) &&
                f.departure_date.Date == departureDate.Date)
                .OrderBy(f => f.price);
        }
    }
}
