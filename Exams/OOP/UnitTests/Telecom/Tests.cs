namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        private Phone phone1;
        
        [SetUp]
        public void Setup()
        {
            this.phone1 = new Phone("Samsung", "S2");
        }
        [Test]
        public void CtorIsNotNull()
        {
            Assert.IsNotNull(phone1);
        }
        [Test]
        public void CtorReturnModel()
        {
            Assert.AreEqual("S2", phone1.Model);
        }
        [Test]
        public void CtorReturnMake()
        {
            Assert.AreEqual("Samsung", phone1.Make);
        }
        [Test]
        public void ExceptionIfNullMake()
        {
            Assert.That(() => new Phone(null, "S3"), Throws.ArgumentException);
        }
        [Test]
        public void ExceptionIfNullModel()
        {
            Assert.That(() => new Phone("GoogleException", null), Throws.ArgumentException);
        }
        [Test]
        public void AddContactInvalidOperationException()
        {
            phone1.AddContact("Petar", "0123");
            Assert.That(() => phone1.AddContact("Petar", "32"), Throws.InvalidOperationException);
        }
        [Test]
        public void AddContactCorrectCount()
        {
            phone1.AddContact("Petar", "0123");
            phone1.AddContact("Ivan", "122354123");
            Assert.AreEqual(2, phone1.Count);
        }
        [Test]
        public void CallNonExistingException()
        {
            Assert.That(() => phone1.Call("Gosho"), Throws.InvalidOperationException);
        }
        [Test]
        public void CallExistingReturnString()
        {
            phone1.AddContact("Ivan", "0123");
            Assert.AreEqual("Calling Ivan - 0123...", phone1.Call("Ivan"));
        }        

    }
}