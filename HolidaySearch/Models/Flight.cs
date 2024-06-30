using HolidaySearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Flight : IFlight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public decimal price { get; set; }
        public DateTime departure_date { get; set; }
    }
}
