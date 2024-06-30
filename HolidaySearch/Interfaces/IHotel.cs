using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Interfaces
{
    public interface IHotel
    {
        int Id { get; }
        string Name { get; }
        DateTime ArrivalDate { get; }
        decimal PricePerNight { get; }
        List<string> LocalAirports { get; }
        int Nights { get; }
    }
}
