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
        public IEnumerable<IHotel> _hotels { get; set; }
        public HolidaySearch(IEnumerable<IFlight> flights)
        {
            this._flights = flights;
        }

        public HolidaySearch(IEnumerable<IHotel> hotels)
        {
            this._hotels = hotels;
        }

        public HolidaySearch(IEnumerable<IFlight> flights,  IEnumerable<IHotel> hotels)
        {
            this._flights = flights;
            this._hotels = hotels;
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

            return _flights
                .Where(f =>
                    (departingFrom.Equals("Any", StringComparison.OrdinalIgnoreCase) ||
                     (departingFrom.Equals("London", StringComparison.OrdinalIgnoreCase) &&
                      (f.from.Equals("LGW", StringComparison.OrdinalIgnoreCase) || f.from.Equals("LTN", StringComparison.OrdinalIgnoreCase))) ||
                     f.from.Equals(departingFrom, StringComparison.OrdinalIgnoreCase)) &&
                    f.to.Equals(arrivingTo, StringComparison.OrdinalIgnoreCase) &&
                    f.departure_date.Date == departureDate.Date)
                .OrderBy(f => f.price); // Order by price in ascending order
        }

        /// <summary>
        /// Method to return a IENumberable of hotels
        /// </summary>
        /// <param name="arrivingTo">Arriving to airport</param>
        /// <param name="arrivalDate">Date of arrival</param>
        /// <param name="numberOfNights">Number of nights staying</param>
        /// <returns></returns>
        public IEnumerable<IHotel> SearchForHotel(string arrivingTo, DateTime arrivalDate, int numberOfNights)
        {
            return _hotels.Where(h => h.local_airports.Contains(arrivingTo, StringComparer.OrdinalIgnoreCase)
            && h.arrival_date.Date == arrivalDate.Date
            && h.nights == numberOfNights)
                .OrderBy(h => h.price_per_night);
        }

        /// <summary>
        /// Method to search for package holidays
        /// </summary>
        /// <param name="departingFrom">Departing from airport</param>
        /// <param name="arrivingTo">Arriving at airport</param>
        /// <param name="departureDate">Date of departure</param>
        /// <param name="nights">Number of nights stay</param>
        /// <returns>IEnumerable of package holidays</returns>
        public IEnumerable<IPackageHoliday> SearchForPackageHoliday(string departingFrom, string arrivingTo, DateTime departureDate, int nights)
        {
            IEnumerable<IFlight> flightOptions = SearchForFlights(departingFrom, arrivingTo, departureDate);
            IEnumerable<IHotel> hotelOptions = SearchForHotel(arrivingTo, departureDate, nights);

            // Check if flights or hotels are available
            if (!flightOptions.Any() || !hotelOptions.Any())
            {
                throw new Exception("No flights or hotels found for the given criteria.");
            }

            foreach (IFlight flight in flightOptions)
            {
                foreach (IHotel hotel in hotelOptions)
                {
                    yield return new PackageHoliday
                    {
                        flight = flight,
                        hotel = hotel,
                        totalCost = flight.price + (hotel.price_per_night * hotel.nights)
                    };
                }
            }
        }
    }
}
