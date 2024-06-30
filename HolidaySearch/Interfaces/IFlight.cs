using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Interfaces
{
    public interface IFlight
    {
        int id { get; set; }
        string airline { get; set; }
        string from { get; set; }
        string to { get; set; }
        decimal price { get; set; }
        DateTime departure_date { get; set; }
    }
}
