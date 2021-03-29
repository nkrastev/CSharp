using NUnit.Framework;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private List<Computer> computers;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Computer computer = new Computer("Dell", "XPS", 700);
            Assert.IsNotNull(computer);
        }
        //Computer Manager Tests
        [Test]
        public void CtorComputerManager()
        {
            var list = new ComputerManager();
            Assert.IsNotNull(list);
            Assert.IsNotNull(list.Computers);
        }
        [Test]
        public void CM_Counter()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            Assert.AreEqual(2, list.Count);
        }
        [Test]
        public void CM_AddComputerTwiceExeption()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            list.AddComputer(computer1);
            Assert.That(() => list.AddComputer(computer1), Throws.ArgumentException);
        }
        [Test]
        public void RemoveComputerReturnsTheRemovedOne()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            Assert.AreEqual(computer2, list.RemoveComputer("HP", "Proliant"));
        }
        [Test]
        public void GetComputerByNullReturnsExeption()
        {
            var list = new ComputerManager();
            Computer computer = new Computer("Dell", "XPS", 700);
            Assert.That(
                () => 
                list.GetComputer("Pesho", "Gosho"), 
                Throws.ArgumentException);
        }
        [Test]
        public void GetComputersByManufactorerReturnsCollection()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            Computer computer3 = new Computer("HP", "Some Model", 1510);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            list.AddComputer(computer3);

            ICollection<Computer> expectedCollection = new List<Computer>();
            expectedCollection.Add(computer2);
            expectedCollection.Add(computer3);

            CollectionAssert.AreEquivalent(expectedCollection, list.GetComputersByManufacturer("HP"));
        }

        [Test]
        public void TestPrivateMethodValidator()
        {
            var list = new ComputerManager();
            Assert.That(() => list.AddComputer(null), Throws.ArgumentNullException);
        }

    }
}