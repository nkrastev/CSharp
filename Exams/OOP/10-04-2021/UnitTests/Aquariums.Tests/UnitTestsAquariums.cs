using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aquariums.Tests
{
    public class UnitTestsAquariums
    {
        private Aquarium aquarium;
        private Fish fish1;
        private Fish fish2;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("FreshAquarium", 10);
            this.fish1 = new Fish("Pesho");
            this.fish2 = new Fish("Gosho");
        }

        [Test]
        public void TestCtor()
        {            
            Assert.IsNotNull(aquarium);
        }
        [Test]
        public void GetterAquariumName()
        {
            Assert.AreEqual("FreshAquarium", aquarium.Name);
        }
        [Test]
        public void NewAquariumWithNullNameResultExeption()
        {
            Assert.That(() => new Aquarium(null, 5), Throws.ArgumentNullException);
        }
        [Test]
        public void GetterAquariumCapacity()
        {
            Assert.AreEqual(10, aquarium.Capacity);
        }
        [Test]
        public void NewAquariumWithNegativeCapacityResultExeption()
        {
            Assert.That(() => new Aquarium("AqName", -5), Throws.ArgumentException);
        }
        [Test]
        public void CounterOfTheFishesInAquarium()
        {
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void AddingFishIncreaseTheCountOfAquarium()
        {
            aquarium.Add(fish1);
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void AddingFishWhenThereIsNoPlaceReturnsException()
        {
            Aquarium aquariumWithNoCapacity = new Aquarium("TestAquarium", 0);
            Assert.That(() => aquariumWithNoCapacity.Add(fish1), Throws.InvalidOperationException);
        }
        [Test]
        public void RemovingFishDecreaseTheCount()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            aquarium.RemoveFish("Pesho");
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void RemovingFishThrowsExceptionIfFishIsMissing()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.That(() => aquarium.RemoveFish("Genadi"), Throws.InvalidOperationException);
        }
        [Test]
        public void SellFishExceptionIfFishIsMissing()
        {
            Assert.That(() => aquarium.SellFish("Zaharin"), Throws.InvalidOperationException);
        }
        [Test]
        public void SellingFishChangeItsStatusToNotAvailable()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.SellFish("Gosho");
            Assert.AreEqual(false, fish2.Available);
        }
        //TODO Test? Selling fish returns fish as result

        [Test]
        public void ReportReturnsString()
        {
            aquarium.Add(fish1);
            Assert.AreEqual("Fish available at FreshAquarium: Pesho", aquarium.Report());
        }
    }
}
