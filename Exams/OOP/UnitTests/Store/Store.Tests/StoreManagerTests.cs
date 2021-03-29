using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProductCtorIsNotNull()
        {
            Product product = new Product("test", 5, 22);
            Assert.IsNotNull(product);
        }
        [Test]
        public void ProductNameNotNull()
        {
            Product product = new Product("test", 5, 22);
            Assert.IsNotNull(product.Name);
        }
        [Test]
        public void ProductPriceNotNull()
        {
            Product product = new Product("test", 5, 22);
            Assert.IsNotNull(product.Price);
        }
        [Test]
        public void StoreManagerCtorIsNotNull()
        {
            StoreManager store = new StoreManager();
            Assert.IsNotNull(store);
        }
        [Test]
        public void StoreManagerCounterValue()
        {
            StoreManager store = new StoreManager();
            Product product = new Product("Test", 1, 5);
            store.AddProduct(product);
            Assert.AreEqual(1, store.Count);
        }
        [Test]
        public void StoreManagerProductNullExeption()
        {
            StoreManager store = new StoreManager();
            Product product = null;
            Assert.That(() => store.AddProduct(product), Throws.ArgumentNullException);
        }
        [Test]
        public void StoreManagerProductQuantityLessThan0Exeption()
        {
            StoreManager store = new StoreManager();
            Product product = new Product("Test", -1, 3);
            Assert.That(() => store.AddProduct(product), Throws.ArgumentException);
        }
        [Test]
        public void StoreManagerBuyProductIfProductNullExeption()
        {
            StoreManager store = new StoreManager();
            //List<Product> products = new List<Product>();
            Product product1 = new Product("test1", 1, 2);
            Product product2 = new Product("test2", 5, 15);
            //products.Add(product1);
            //products.Add(product2);
            store.AddProduct(product1);
            Assert.That(() => store.BuyProduct("test3", 5), Throws.ArgumentNullException);
        }
        [Test]
        public void StoreManagerBuyProductIfQuantityMoreThanAvailableExeption()
        {
            StoreManager store = new StoreManager();
          
            Product product1 = new Product("test1", 1, 2);
            Product product2 = new Product("test2", 5, 15);
          
            store.AddProduct(product1);
            Assert.That(() => store.BuyProduct("test1", 5), Throws.ArgumentException);
        }

        [Test]
        public void StoreManagerBuyProductDecreaseQuantity()
        {
            StoreManager store = new StoreManager();

            Product product1 = new Product("test1", 5, 2);            

            store.AddProduct(product1);
            store.BuyProduct("test1", 3);
            //throws exeption cause there are not enought quantity
            Assert.That(() => store.BuyProduct("test1", 5), Throws.ArgumentException);
        }
        [Test]
        public void StoreManagerMostExpensiveProductGet()
        {
            StoreManager store = new StoreManager();

            Product product1 = new Product("test1", 5, 2);
            Product product2 = new Product("test2", 5, 73);
            Product product3 = new Product("test3", 5, 173);
            Product product4 = new Product("test4", 5, 70);

            store.AddProduct(product1);
            store.AddProduct(product2);
            store.AddProduct(product3);
            store.AddProduct(product4);

            Assert.AreEqual(173, store.GetTheMostExpensiveProduct().Price);
        }
        [Test]
        public void ReturnProductCollection()
        {
            StoreManager store = new StoreManager();

            Product product1 = new Product("test1", 5, 2);
            Product product2 = new Product("test2", 5, 73);
            Product product3 = new Product("test3", 5, 173);
            Product product4 = new Product("test4", 5, 70);

            store.AddProduct(product1);
            store.AddProduct(product2);
            store.AddProduct(product3);
            store.AddProduct(product4);

            List<Product> productsList = new List<Product>();
            productsList.Add(product1);
            productsList.Add(product2);
            productsList.Add(product3);
            productsList.Add(product4);

            CollectionAssert.AreEquivalent(store.Products, productsList);
        }
    }
}