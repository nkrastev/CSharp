using NUnit.Framework;

namespace Aquariums.Tests
{
    public class UnitTestsFish
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Fish fish = new Fish("Pesho");
            Assert.IsNotNull(fish);
        }
    }
}