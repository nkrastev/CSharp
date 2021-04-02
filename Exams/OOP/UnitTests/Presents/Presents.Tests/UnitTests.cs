using NUnit.Framework;
using System.Collections.Generic;

namespace Presents.Tests
{
    public class Tests
    {
        private Present present1;
        private Present present2;
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            this.present1 = new Present("Playstation", 17.8);
            this.present2 = new Present("Xbox", 12.3);
            this.bag = new Bag();
        }

        [Test]
        public void TestBothCtorsNotNull()
        {            
            Assert.IsNotNull(present1);
            Assert.IsNotNull(bag);
        }
        [Test]
        public void BagCreatePresentExceptionIfPresentNull()
        {
            Assert.That(() => bag.Create(null), Throws.ArgumentNullException);
        }
        [Test]
        public void BagCreatePresentExceptionIfPresentAlreadyExist()
        {
            bag.Create(present1);
            Assert.That(() => bag.Create(present1), Throws.InvalidOperationException);
        }
        [Test]
        public void SuccessfullyCreatePresentToTheBag()
        {
            Assert.AreEqual("Successfully added present Playstation.", bag.Create(present1));
        }
        [Test]
        public void RemovePresentReturnsTrueIfPresentExist()
        {
            bag.Create(present1);
            Assert.AreEqual(true, bag.Remove(present1));
        }
        [Test]
        public void RemovePresentReturnsFalseIfPresentMissing()
        {            
            Assert.AreEqual(false, bag.Remove(present1));
        }
        [Test]
        public void GetPresentWithLeastMagicReturnsXbox()
        {
            bag.Create(present1);
            bag.Create(present2);
            Assert.AreEqual("Xbox", bag.GetPresentWithLeastMagic().Name);
        }
        [Test]
        public void GetPresentByName()
        {
            bag.Create(present1);
            bag.Create(present2);
            Assert.AreEqual(present2.Name, bag.GetPresent("Xbox").Name);
        }
        [Test]
        public void ReturnAllPresentsInTheBagAsCollection()
        {
            bag.Create(present1);
            bag.Create(present2);

            List<Present> list = new List<Present>();
            list.Add(present1);
            list.Add(present2);

            CollectionAssert.AreEquivalent(list, bag.GetPresents());
        }


    }
}