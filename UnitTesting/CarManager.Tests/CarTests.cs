//using CarManager;
//using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorCarCreation()
        {
            //Arrange and Act
            Car car = new Car("Ford", "Mustang", 2.2, 90);

            //Assert
            Assert.IsNotNull(car);
        }
        [Test]
        public void PropertyMake_ArgumentExeptionIfNull()
        {
            //Arrange
            string make = string.Empty;
            //Act and Assert
            Assert.That(()=> new Car(make, "Mustang", 1,1),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        public void PropertyMake_ArgumentExeptionIfEmpty()
        {
            //Arrange
            string make = "";
            //Act and Assert
            Assert.That(() => new Car(make, "Mustang", 1, 1),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        public void PropertyMake_RegularSet()
        {
            //Arrange
            Car car = new Car("Ford", "Mustang", 1, 1);
            //Act and Assert
            Assert.AreEqual("Ford", car.Make);
        }

        [Test]
        public void PropertyModel_ArgumentExeptionIfNull()
        {
            //Arrange
            string model = null;
            //Act and Assert
            Assert.That(() => new Car("Ford", model, 1, 1),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Model cannot be null or empty!"));
        }
        [Test]
        public void PropertyModel_ArgumentExeptionIfEmpty()
        {
            //Arrange
            string model = string.Empty;
            //Act and Assert
            Assert.That(() => new Car("Ford", model, 1, 1),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void PropertyModel_RegularSet()
        {
            //Arrange
            Car car = new Car("Ford", "Mustang", 1, 1);
            //Act and Assert
            Assert.AreEqual("Mustang", car.Model);
        }

        [Test]
        public void Property_FuelConsumptionGetter()
        {
            Car car = new Car("F", "M", 3.2, 90);
            Assert.AreEqual(3.2, car.FuelConsumption);
        }
        [Test]
        public void Property_FuelConsumptionNegativeNumber()
        {            
            Assert.That(() => new Car("F", "M", -5, 90),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Fuel consumption cannot be zero or negative!")
                );
        }
        [Test]
        public void Property_FuelConsumptionZero()
        {
            Assert.That(() => new Car("F", "M", 0, 90),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Fuel consumption cannot be zero or negative!")
                );
        }
        [Test]
        public void Property_FuelAmountNewCarHaveToBeWithEmptyTank()
        {
            Car car = new Car("F", "M", 3.2, 90);            
            Assert.AreEqual(0, car.FuelAmount);
        }
        //TO DO TEST WITH NEGATIVE FUEL AMOUNT

        [Test]
        public void Property_FuelCapacityGetter()
        {
            Car car = new Car("F", "M", 3.2, 90);
            Assert.AreEqual(90, car.FuelCapacity);
        }

        [Test]
        public void Property_FuelCapacityZero()
        {
            Assert.That(() => new Car("F", "M", 5, 0),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Fuel capacity cannot be zero or negative!")
                );
        }
        [Test]
        public void Property_FuelCapacityNegative()
        {
            Assert.That(() => new Car("F", "M", 5, -50),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Fuel capacity cannot be zero or negative!")
                );
        }

        [Test]
        public void MethodRefuel_WithNegativeNumberException()
        {
            Car car = new Car("F", "M", 3.2, 90);
            Assert.That(() => car.Refuel(-5),
                Throws.
                ArgumentException.
                With.
                Message.
                EqualTo("Fuel amount cannot be zero or negative!")
                );
        }
        [Test]
        public void MethodRefuel_RegularRefuel()
        {
            //Arrange
            Car car = new Car("F", "M", 3.2, 90);
            //Act
            car.Refuel(1.8);
            //Assert
            Assert.AreEqual(1.8, car.FuelAmount);
        }
        [Test]
        public void MethodRefuelWithMoreThanTankCapacity_ResultTankIsFull()
        {
            //Arrange
            Car car = new Car("F", "M", 3.2, 90);
            //Act
            car.Refuel(1000);
            //Assert
            Assert.AreEqual(90, car.FuelAmount);            
        }
        [Test]
        public void MethodDriveWithEnoughtFuel_IsFuelDecreasingCorrect()
        {
            //Arrange
            Car car = new Car("F", "M", 1.0, 100);
            //Act, refuel and Drive the car
            car.Refuel(100);
            car.Drive(100);
            //Assert
            Assert.AreEqual(99, car.FuelAmount);
        }
        [Test]
        public void MethodDriveWithNotEnoughtFuel()
        {
            //Arrange
            Car car = new Car("F", "M", 10, 50);
            //Act, refuel
            car.Refuel(10);
            //Assert
            Assert.That(() => car.Drive(1000),
                Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!")
            );
        }

    }
}