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
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal PricePerNight { get; set; }
        public List<string> LocalAirports { get; set; }
        public int Nights { get; set; }
    }
}
