using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;
    using System.Collections;
    using System;
    public class ExtendedDatabaseTests
    {        
        private ExtendedDatabase database;
        private Person[] invalidArrayOfPeople = new Person[17];
        private Person[] validArrayOfPeople = new Person[16];
        private Person ivanWithId4 = new Person(4, "Ivan");

        [SetUp]
        public void Setup()
        {
            var validArrayOfPeople = new Person[16];
            var invalidArrayOfPeople = new Person[17];
        }

        [Test]
        public void CtorCreatingPerson()
        {
            //arrange and act
            var expectedPerson = new Person(4, "Ivan");
            //assert
            Assert.IsNotNull(expectedPerson);
        }
        [Test]
        public void CtorExtendedDatabase()
        {
            database = new ExtendedDatabase(new Person(1, "Test"));
            //assert
            Assert.IsNotNull(database.Count);
        }

        [Test]
        public void CtorTestIfMoreThan16PeopleInitialized()
        {
            Assert.That(() => new ExtendedDatabase(invalidArrayOfPeople),
                Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void AddingIfUserExistThrowExeption()
        {
            //arrange
            database = new ExtendedDatabase(new Person(1, "Test"));

            //act and assert, try to add person test again
            Assert.That(() => database.Add(new Person(2, "Test")),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddingIfUserWithSameIdExistThrowExeption()
        {
            //arrange
            database = new ExtendedDatabase(new Person(1, "Test"));

            //act and assert, try to add person test again
            Assert.That(() => database.Add(new Person(1, "PetarTest")),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddUserIfDatabaseIsWith16Users_ExceptionExpected()
        {
            //arrange
            var database = new ExtendedDatabase();
            for (int i = 0; i < 16; i++)
            {
                var newPerson = new Person(i, $"Test{i}");
                database.Add(newPerson);
            }
            //act and assert
            Assert.That(() => database.Add(new Person(17, "PetarTest")),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveUserFromDatabaseCountDecreased() 
        {
            //arrange
            database = new ExtendedDatabase(new Person(1, "Test"));

            //act
            database.Remove();

            //assert
            Assert.AreEqual(database.Count, 0);
        }
        [Test]
        public void RemoveUserFromEmptyDatabaseException()
        {
            //arrange
            database = new ExtendedDatabase();            
            
            //act and assert            
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FindByUsernameIfNoUserIsFoundInvalidExeption()
        {
            //arrange
            database = new ExtendedDatabase(new Person(1,"Test"));            
            //act and assert
            Assert.That(() => database.FindByUsername("InvalidName"),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo("No user is present by this username!"));
        }
        [Test]
        public void FindByUsernameWithNullArgument_InvalidArgumentException()
        {
            //arrange
            database = new ExtendedDatabase(new Person(1, "Test"));
            string username = null;

            //act and assert
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }
        [Test]
        public void FindByUsernameWithExistingPerson_Person()
        {
            //arrange 
            database = new ExtendedDatabase(new Person(1, "test"));
            Person searchedPerson = new Person(1, "test");

            //act and assert
            Assert.AreEqual(
                searchedPerson.Id, 
                database.FindByUsername("test").Id);           
        }

        [Test]
        public void FindByIdIfNoId_InvalidOperationException()
        {
            //arrange
            database = new ExtendedDatabase(new Person(1, "test"));

            //act and assert
            Assert.That(() => database.FindById(3),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdWithNegativeId_ArgumentOutOfRangeException()
        {
            //arrange act and assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>database.FindById(-1));            
        }
        [Test]
        public void FindByIdReturnsObjectPerson()
        {
            database = new ExtendedDatabase(new Person(1, "test"));
            Person searchedPerson = new Person(1, "test");

            Assert.AreEqual(
                searchedPerson.UserName,
                database.FindById(1).UserName);
        }


    }
}