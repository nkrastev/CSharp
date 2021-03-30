using NUnit.Framework;

namespace ParkingSystem.Tests
{
    public class Tests
    {
        private Car car1;
        private Car car2;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            this.car1 = new Car("Bmw", "CB1530PP");
            this.car2 = new Car("Audi", "CA5522PP");
        }

        //Car Tests
        [Test]
        public void CarCtorIsNotNull()
        {            
            Assert.IsNotNull(car1);
        }
        [Test]
        public void CarGetterMake()
        {           
            Assert.AreEqual("Bmw", car1.Make);
        }
        [Test]
        public void CarGetterPlateNumber()
        {        
            Assert.AreEqual("CB1530PP", car1.RegistrationNumber);
        }
        //Parking Tests
        [Test]
        public void CtorSoftPark()
        {            
            Assert.IsNotNull(softPark);
            Assert.IsNotNull(softPark.Parking);
        }
        [Test]
        public void ParkCarOnNonExistingSpotExeption()
        {
            Assert.That(() => softPark.ParkCar("J974", car1), Throws.ArgumentException);
        }
        [Test]
        public void ParkCarOnOccupiedSpotExeption()
        {
            softPark.ParkCar("A1", car1);
            Assert.That(() => softPark.ParkCar("A1", car2), Throws.ArgumentException);
        }
        [Test]
        public void ParkCarWhichIsAlreadyParkedExeption()
        {
            softPark.ParkCar("A1", car1);
            Assert.That(() => softPark.ParkCar("A3", car1), Throws.InvalidOperationException);
        }

        [Test]
        public void ParkCarRegularReturnsString()
        {
            Assert.AreEqual("Car:CB1530PP parked successfully!", softPark.ParkCar("A1", car1));
        }
        [Test]
        public void RemoveCarFromNonExistingSpotExeption()
        {
            Assert.That(() => softPark.RemoveCar("J132", car1), Throws.ArgumentException);
        }
        [Test]
        public void RemoveCarNonExistingCarSpotExeption()
        {
            Assert.That(() => softPark.RemoveCar("A1", car1), Throws.ArgumentException);
        }
        [Test]
        public void RemoveCarFreesSpot()
        {
            softPark.ParkCar("A1", car1);
            Assert.AreEqual("Remove car:CB1530PP successfully!", softPark.RemoveCar("A1", car1));            
        }

    }
}