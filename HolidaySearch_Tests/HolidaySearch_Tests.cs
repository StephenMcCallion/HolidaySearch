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

        [Test]
        public void SearchForPackageHoliday_Test()
        {
            IHolidaySearch holidaySearch = new HolidaySearch.Models.HolidaySearch(flights, hotels);
            IEnumerable<IPackageHoliday> packageOptions = holidaySearch.SearchForPackageHoliday("MAN", "AGP", new DateTime(2023, 07, 01), 7);
            IPackageHoliday result = packageOptions.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.flight.id, 2);
            Assert.AreEqual(result.flight.from, "MAN");
            Assert.AreEqual(result.flight.to, "AGP");
            Assert.AreEqual(result.flight.price, 245);
            Assert.AreEqual(result.hotel.id, 9);
            Assert.AreEqual(result.hotel.name, "Nh Malaga");
            Assert.AreEqual(result.hotel.price_per_night, 83);
            Assert.AreEqual(result.totalCost, 826);   
        }

        [Test]
        public void SearchForPackageHoliday_Customer2_Test()
        {
            IHolidaySearch holidaySearch = new HolidaySearch.Models.HolidaySearch(flights, hotels);
            IEnumerable<IPackageHoliday> packageOptions = holidaySearch.SearchForPackageHoliday("London", "PMI", new DateTime(2023, 06, 15), 10);
            IPackageHoliday result = packageOptions.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.flight.id, 6);
            Assert.AreEqual(result.flight.from, "LGW");
            Assert.AreEqual(result.flight.to, "PMI");
            Assert.AreEqual(result.flight.price, 75);
            Assert.AreEqual(result.hotel.id, 5);
            Assert.AreEqual(result.hotel.name, "Sol Katmandu Park & Resort");
            Assert.AreEqual(result.hotel.price_per_night, 60);
            Assert.AreEqual(result.totalCost, 675);
        }
    }
}
