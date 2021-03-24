using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initialData);
        }

        [Test]
        public void TestConstructorWith2Elements()
        {
            //Arrange            
            var expected = new int[] { 1, 2 };

            //Act

            //Assert
            Assert.AreEqual(expected.Length, this.database.Count);
        }

        [Test]
        public void TestConstructorMoreThan16Elements()
        {
            //arrange
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            //assert
            Assert.That(() => new Database(expected), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!")
                );
        }

        [Test]
        public void AddingNewElementShouldIncreaseCount()
        {
            //arrange
            var newElement = 5;
            var currentElements = database.Count;
            //act
            database.Add(newElement);

            //assert
            Assert.AreEqual(currentElements + 1, database.Count);

        }

        [Test]
        public void IfThere16ElementsAddingNewOneWillThrowExeption()
        {
            //arrange 16 elements
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var dbWith16Elements = new Database(input);

            //Assert with act inside
            Assert.That(
                () => dbWith16Elements.Add(1), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!")
                );
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            //arrange using this.database with the initial elements
            var actualCount = database.Count;
            //act
            this.database.Remove();
            //assert
            Assert.AreEqual(actualCount - 1, database.Count);
        }
        [Test]
        public void TryToRemoveElementFromEmptyDatabase()
        {
            //arrange
            var emptyArray = new int[0];
            var emptyDb = new Database(emptyArray);
            //assert & act
            Assert.That(
                () => emptyDb.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!")
            );
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopy(int[] data)
        {
            this.database = new Database(data);

            //act
            int[] actualData = this.database.Fetch();

            //assert
            CollectionAssert.AreEqual(data, actualData);

        }
    }
}