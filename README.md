# Holiday Search Library

This library provides a basic holiday search feature based on given flight and hotel data. It allows users to find the best value holiday based on specified search criteria.

## Features

- Search for holidays based on departure location, destination, departure date, and duration.
- Return the best value holiday based on total price.
- Adheres to SOLID principles and uses Test-Driven Development (TDD).

## Getting Started

### Prerequisites

- .NET 7.0 or later
- Newtonsoft.Json for JSON deserialization
- Nunit for unit testing

### Installation

1. Clone the repository:

   ```bash
   git clone [https://github.com/yourusername/solid-holiday-search.git](https://github.com/StephenMcCallion/HolidaySearch.git)
   ```
2. Navigate to the project directory:
   ```bash
   cd solid-holiday-search
   ```
3. Restore the dependencies:
   ```bash
   dotnet restore
   ```
### Project Structure
* HolidaySearch
  - Interfaces
    - IFlight.cs
    - IHolidaySearch.cs
    - IHotel.cs
    - IPackageHoliday.cs  
  - Models
    - Flight.cs
    - HolidaySearch.cs
    - Hotel.cs
    - PackageHoliday.cs
* HolidaySearch_Tests
  - Data
    - FlightData.json
    - HotelData.json
  - HolidaySearch_Tests.cs
### Running Tests
1. Navigate to the test project directory:
   ```bash
   cd HolidaySearch.Tests
   ```

2. Run the tests:
   ```bash
   dotnet test
   ```
