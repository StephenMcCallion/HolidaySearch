using HolidaySearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class PackageHoliday : IPackageHoliday
    {
        public IFlight flight { get; set; }
        public IHotel hotel { get; set; }
        public decimal totalCost { get; set; }
    }
}
