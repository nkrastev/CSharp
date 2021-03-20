using NUnit.Framework;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            RaceEntry raceEntry = new RaceEntry();
        }

        [Test]
        public void ConstructorOfMainClass()
        {
            var raceEntry = new RaceEntry();
            Assert.IsNotNull(raceEntry);
        }
        [Test]
        public void AddingNewDriverIncreaseCount()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("TestModel", 7, 1000);
            var driver = new UnitDriver("Test", car);
            raceEntry.AddDriver(driver);
            Assert.AreEqual(1, raceEntry.Counter);
        }
        [Test]
        public void AddDriverIOEifDriverIsNull()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("TestModel", 7, 1000);
            var driver = new UnitDriver("Test", car);
            driver = null;
            Assert.That(() => raceEntry.AddDriver(driver), Throws.InvalidOperationException);           
        }
        [Test]
        public void AddingExistingDriverReturnsIOE()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("TestModel", 7, 1000);
            var anotherCar = new UnitCar("Another TestModel", 17, 1000);
            var driver = new UnitDriver("Test", car);
            raceEntry.AddDriver(driver);
            var driverWithSameName = new UnitDriver("Test", anotherCar);
            Assert.That(() => raceEntry.AddDriver(driverWithSameName), Throws.InvalidOperationException);
        }
        [Test]
        public void AddingDriverReturnsString()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("TestModel", 7, 1000);
            var driver = new UnitDriver("Test", car);            
            Assert.AreEqual($"Driver {driver.Name} added in race.", raceEntry.AddDriver(driver));
        }
        [Test]
        public void AverageHorsePowersFor2Cars()
        {
            var raceEntry = new RaceEntry();
            var car1 = new UnitCar("TestModel", 7, 1000);
            var driver1 = new UnitDriver("Test", car1);
            raceEntry.AddDriver(driver1);

            var car2 = new UnitCar("TestModel", 10, 1000);
            var driver2 = new UnitDriver("Test2", car2);
            raceEntry.AddDriver(driver2);

            Assert.AreEqual(8.5, raceEntry.CalculateAverageHorsePower());
        }
    }
}