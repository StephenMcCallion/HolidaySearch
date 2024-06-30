using HolidaySearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Hotel : IHotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime arrival_date { get; set; }
        public decimal price_per_night { get; set; }
        public List<string> local_airports { get; set; }
        public int nights { get; set; }
    }
}
