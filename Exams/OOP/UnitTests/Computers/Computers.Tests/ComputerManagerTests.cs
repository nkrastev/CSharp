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
            //Assert.IsNotNull(list.Computers);
        }
        [Test]
        public void IReadOnlyCollectionTest()
        {
            var list = new ComputerManager();
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
            Assert.That(() => list.AddComputer(computer1), 
                Throws.ArgumentException.With.Message.EqualTo("This computer already exists.")
                );
        }

        [Test]
        public void CM_AddComputerSuccess()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            list.AddComputer(computer1);
            Assert.AreEqual(1, list.Computers.Count);
        }

        [Test]
        public void CM_AddComputerNull()
        {
            var list = new ComputerManager();
            Assert.That(()=> list.AddComputer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void RemoveComputerExceptionIfComputerNull()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            Assert.That(() => list.RemoveComputer(null, null), Throws.ArgumentNullException);            
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
        public void RemoveComputerDecreaseCount()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            list.RemoveComputer("HP", "Proliant");
            Assert.AreEqual(1, list.Computers.Count);
        }
        [Test]
        public void GetComputerByNullReturnsExeption()
        {
            var list = new ComputerManager();
            Computer computer = new Computer("Dell", "XPS", 700);
            Assert.That(
                () =>
                list.GetComputer("Pesho", "Gosho"),
                Throws.ArgumentException.With.Message.EqualTo("There is no computer with this manufacturer and model."));
        }

        [Test]
        public void GetComputerReturnsExceptionWithFirstFieldNull()
        {
            var list = new ComputerManager();
            Computer computer = new Computer("Dell", "XPS", 700);
            Assert.That(
                () =>
                list.GetComputer(null, "Gosho"),
                Throws.ArgumentNullException);
        }
        [Test]
        public void GetComputerReturnsExceptionWithSecondFieldNull()
        {
            var list = new ComputerManager();
            Computer computer = new Computer("Dell", "XPS", 700);
            Assert.That(
                () =>
                list.GetComputer("Test", null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void GetComputerByReturnsComputer()
        {
            var list = new ComputerManager();
            Computer computer = new Computer("Dell", "XPS", 700);
            list.AddComputer(computer);
            Assert.AreEqual(computer, list.GetComputer("Dell", "XPS"));
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

            CollectionAssert.AreEqual(expectedCollection, list.GetComputersByManufacturer("HP"));
        }
        [Test]
        public void GetComputersByManufactorerReturnsEmptyCollection()
        {
            var list = new ComputerManager();
            Computer computer1 = new Computer("Dell", "XPS", 700);
            Computer computer2 = new Computer("HP", "Proliant", 18700);
            Computer computer3 = new Computer("HP", "Some Model", 1510);
            list.AddComputer(computer1);
            list.AddComputer(computer2);
            list.AddComputer(computer3);
            ICollection<Computer> emptyCollection = new List<Computer>();           
            CollectionAssert.AreEqual(emptyCollection, list.GetComputersByManufacturer("J"));
        }

        [Test]
        public void TestPrivateMethodValidator()
        {
            var list = new ComputerManager();
            Assert.That(() => list.AddComputer(null), Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'computer')"));
        }

    }
}