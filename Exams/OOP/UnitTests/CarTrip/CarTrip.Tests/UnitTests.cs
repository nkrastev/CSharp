using NUnit.Framework;

namespace CarTrip.Tests
{
    public class Tests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("Audi", 90, 37, 10);
        }

        [Test]
        public void CtorIsNotNull()
        {
            Assert.IsNotNull(car);
        }
        [Test]
        public void TankCapacityReturns90()
        {
            Assert.AreEqual(90, car.TankCapacity);
        }
        [Test]
        public void ModelGetter()
        {
            Assert.AreEqual("Audi", car.Model);
        }
        [Test]
        public void ModelSetterException()
        {
            Assert.That(() => new Car(null, 5, 2, 1.5), Throws.ArgumentException);
        }
        [Test]
        public void FuelAmountGetter()
        {
            Assert.AreEqual(37, car.FuelAmount);
        }
        [Test]
        public void FuelAmountMoreThanTankException()
        {
            Assert.That(() => new Car("VW", 5, 10, 1), Throws.ArgumentException);
        }
        [Test]
        public void FuelConsumptionPerKmGetter()
        {
            Assert.AreEqual(10, car.FuelConsumptionPerKm);
        }
        //[Test] NOT TESTABLE fuel consumption didnt go through property but directly to field
        //public void FuelConsumptionPerKmNegativeException()
        //{
        //    Assert.That(
        //        () => new Car("Audi", 15, 10, -2.2), 
        //        Throws.ArgumentException);            
        //}
        [Test]
        public void DriveIfNotEnoughtFuelException()
        {
            Assert.That(() => car.Drive(99999), Throws.InvalidOperationException);
        }
        [Test]
        public void DriveWillDecreaseFuel()
        {
            car.Drive(1);
            Assert.AreEqual(27, car.FuelAmount);            
        }
        [Test]
        public void DriveReturnString()
        {
            Assert.AreEqual("Have a nice trip", car.Drive(1));
        }
        [Test]
        public void RefuelWithMoreThanTankException()
        {
            Assert.That(() => car.Refuel(999), Throws.InvalidOperationException);
        }
        [Test]
        public void RefuelIncreaseFuel()
        {
            car.Refuel(3);
            Assert.AreEqual(40, car.FuelAmount);
        }
    }
}