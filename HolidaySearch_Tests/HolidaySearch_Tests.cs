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
        }

        [Test]
        public void SearchForFlight_Test()
        {
            IHolidaySearch holidaySearch = new HolidaySearch(flights);
            IEnumerable<IFlight> flightOptions = holidaySearch.SearchForFlights("MAN", "TFS", new DateTime(2023, 07, 01));
            IFlight result = flightOptions.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.id, 1);
        }
    }
}
