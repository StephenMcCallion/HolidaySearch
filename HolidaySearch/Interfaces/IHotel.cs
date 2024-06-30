using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Interfaces
{
    public interface IHotel
    {
        int id { get; }
        string name { get; }
        DateTime arrival_date { get; }
        decimal price_per_night { get; }
        List<string> local_airports { get; }
        int nights { get; }
    }
}
