using Newtonsoft.Json;
using HolidaySearch.Interfaces;
using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch_Tests
{
    [TestFixture]
    public class HolidaySearch_Tests
    {
        public IEnumerable<IFlight> flights { get; set; }
        public IEnumerable<IHotel> hotels { get; set; }

        [SetUp]
        public void SetUp()
        {
            try
            {
                flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(File.ReadAllText("../../../Data/FlightData.json"));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to load flight data: {ex.Message}");
            }

            try
            {
                hotels = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(File.ReadAllText("../../../Data/HotelData.json"));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to retrieve hotel data: {ex.Message}");
            }
        }

        [Test]
        public void SearchForFlight_Test()
        {
            IHolidaySearch holidaySearch = new HolidaySearch.Models.HolidaySearch(flights);
            IEnumerable<IFlight> flightOptions = holidaySearch.SearchForFlights("MAN", "TFS", new DateTime(2023, 07, 01));
            IFlight result = flightOptions.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.id, 1);
        }

        [Test]
        public void SearchForHotel_Test()
        {
            IHolidaySearch holidaySearch = new HolidaySearch.Models.HolidaySearch(hotels);
            IEnumerable<IHotel> hotelOptions = holidaySearch.SearchForHotel("TFS", new DateTime(2022, 11, 05), 7);
            IHotel result = hotelOptions.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.id, 2);
        }
    }
}
