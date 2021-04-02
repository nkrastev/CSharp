using NUnit.Framework;
using System.Collections.Generic;

namespace HeroRepositoryNameSpace.Tests
{
    public class Tests
    {
        private Hero hero1;
        private Hero hero2;
        private HeroRepository heroes;

        [SetUp]
        public void Setup()
        {
            this.hero1 = new Hero("Pesho", 3);
            this.hero2 = new Hero("Gosho", 5);
            this.heroes = new HeroRepository();
        }

        [Test]
        public void TestBothCtors()
        {
            Assert.IsNotNull(hero1);
            Assert.IsNotNull(heroes);
        }
        [Test]
        public void GettersOfTheHero()
        {
            Assert.AreEqual("Pesho", hero1.Name);
            Assert.AreEqual(3, hero1.Level);
        }
        //Hero Repository Tests
        [Test]
        public void CreateNullHeroArgumentNullException()
        {
            Assert.That(() => heroes.Create(null), Throws.ArgumentNullException);
        }
        [Test]
        public void CreateExistingHeroInvalidOperationException()
        {
            heroes.Create(hero1);
            Assert.That(() => heroes.Create(hero1), Throws.InvalidOperationException);
        }
        [Test]
        public void CreateHeroReturnsString()
        {
            Assert.AreEqual("Successfully added hero Pesho with level 3", heroes.Create(hero1));
        }
        [Test]
        public void RemoveNullHeroArgumentNullException()
        {
            Assert.That(() => heroes.Remove(null), Throws.ArgumentNullException);
        }
        [Test]
        public void RemoveHeroReturnsTrue()
        {
            heroes.Create(hero1);
            Assert.AreEqual(true, heroes.Remove("Pesho"));
        }
        [Test]
        public void RemoveHeroReturnsFalse()
        {
            heroes.Create(hero1);
            Assert.AreEqual(false, heroes.Remove("zaharin"));
        }
        [Test]
        public void GetHeroWithHighestLevelReturnsGosho()
        {
            heroes.Create(hero1);
            heroes.Create(hero2);
            Assert.AreEqual("Gosho", heroes.GetHeroWithHighestLevel().Name);
        }
        [Test]
        public void GetHeroByNameReturnsPeshosLevel3()
        {
            heroes.Create(hero1);
            heroes.Create(hero2);
            Assert.AreEqual(3, heroes.GetHero("Pesho").Level);
        }
        [Test]
        public void HeroesCollection()
        {
            heroes.Create(hero1);
            heroes.Create(hero2);

            List<Hero> list = new List<Hero>();
            list.Add(hero1);
            list.Add(hero2);

            CollectionAssert.AreEquivalent(list, heroes.Heroes);
        }
    }
}