using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Interfaces
{
    public interface IHolidaySearch
    {
        IEnumerable<IFlight> SearchForFlights(string departingFrom, string arrivingTo, DateTime deptartureDate);
        IEnumerable<IHotel> SearchForHotel(string arrivingTo, DateTime arrivalDate, int numberOfNights);

    }
}
