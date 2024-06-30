using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Interfaces
{
    public interface IPackageHoliday
    {
        IFlight flight { get; set; }
        IHotel hotel { get; set; }
        decimal totalCost { get; set; }

    }
}
