namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship1;
        private Astronaut astronaut1;
        private Astronaut astronaut2;

        [SetUp]
        public void Setup()
        {
            spaceship1 = new Spaceship("Apolo", 17);
            astronaut1 = new Astronaut("Neil", 72.4);
            astronaut2 = new Astronaut("Edwin", 42.5);

        }

        //Astronaut tests
        [Test]
        public void AstronautCtorNull()
        {
            Astronaut astronaut = new Astronaut("AstrName", 37.3);
            Assert.IsNotNull(astronaut);
        }
        [Test]
        public void AstronautNameGetter()
        {
            Astronaut astronaut = new Astronaut("AstrName", 37.3);
            Assert.AreEqual("AstrName", astronaut.Name);
        }
        [Test]
        public void AstronautOxigenGetter()
        {
            Astronaut astronaut = new Astronaut("AstrName", 37.3);
            Assert.AreEqual(37.3, astronaut.OxygenInPercentage);
        }

        //Spaceship Tests
        [Test]
        public void SpaceShipCtorIsNotNull()
        {            
            Assert.IsNotNull(spaceship1);
        }
        [Test]
        public void SpaceShipCountGetter()
        {
            spaceship1.Add(astronaut1);
            Assert.AreEqual(1, spaceship1.Count);
        }
        [Test]
        public void SpaceShipWithNullName()
        {
            Assert.That(() => new Spaceship(null, 7), Throws.ArgumentNullException);
        }
        [Test]
        public void SpaceShipWithNameReturnName()
        {
            Spaceship spaceship = new Spaceship("Mir", 7);
            Assert.AreEqual("Mir", spaceship.Name);
        }
        [Test]
        public void SpaceShipWithNegativeCapacityException()
        {
            Assert.That(() => new Spaceship("Union", -7), Throws.ArgumentException);
        }
        [Test]
        public void SpaceShipWithCapacityReturnCapacity()
        {
            Spaceship spaceship = new Spaceship("Mir", 7);
            Assert.AreEqual(7, spaceship.Capacity);
        }
        [Test]
        public void AddAstronautWithNotEnoughtCapacityException()
        {
            Spaceship spaceship = new Spaceship("Mir", 0);
            Assert.That(() => spaceship.Add(astronaut1), Throws.InvalidOperationException);
        }
        [Test]
        public void AddAstronautExistingAstronautException()
        {
            Spaceship spaceship = new Spaceship("Mir", 5);
            spaceship.Add(astronaut1);
            Assert.That(() => spaceship.Add(astronaut1), Throws.InvalidOperationException);
        }
        [Test]
        public void AddAstronautIncreaseCount()
        {
            Spaceship spaceship = new Spaceship("Mir", 5);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            Assert.AreEqual(2, spaceship.Count);
        }
        [Test]
        public void RemoveIfExistReturnTrue()
        {
            Spaceship spaceship = new Spaceship("Apolo", 5);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            Assert.AreEqual(true, spaceship.Remove("Neil"));
        }
        [Test]
        public void RemoveIfNOTExistReturnFalse()
        {
            Spaceship spaceship = new Spaceship("Apolo", 5);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            Assert.AreEqual(false, spaceship.Remove("Pesho"));
        }

    }
}