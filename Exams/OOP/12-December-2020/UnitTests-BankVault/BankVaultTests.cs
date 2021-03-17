using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault trezor;
        
        [SetUp]
        public void Setup()
        {
            var item = new Item("TestOwner", "1TestId");
            var item1 = new Item("TestOwner1", "TestId_1");
            var item2 = new Item("TestOwner2", "TestId_2");
            var item3 = new Item("TestOwner3", "TestId_3");

            BankVault trezor = new BankVault();
            trezor.AddItem("A1", item1);
            trezor.AddItem("B1", item2);
        }

        [Test]
        public void GetterItemOwnerName()
        {
            var item = new Item("TestOwner", "1TestId");
            Assert.AreEqual("TestOwner", item.Owner);
        }
        [Test]
        public void GetterItemId()
        {
            var item = new Item("TestOwner", "1TestId");
            Assert.AreEqual("1TestId", item.ItemId);
        }
        [Test]
        public void BankVaultCtor()
        {
            //TODO Test Constructor
            //Assert.IsNotNull(trezor);
        }

        [Test]
        public void BankVaultHasSellsAfterCreation()
        {
            BankVault bankVault = new BankVault();
            Assert.IsNotNull(bankVault.VaultCells.Count);
        }

        [Test]
        public void AddItemIfNotContainKeyException()
        {
            Item itemTest = new Item("TestOwner3", "TestId_3");
            BankVault trezor = new BankVault();
            Assert.That(() => trezor.AddItem("NotExistingCell", itemTest), Throws.ArgumentException);          
        }

        [Test]
        public void AddItemIfCellIsNotEmptyException()
        {
            Item itemTest = new Item("TestOwner3", "TestId_3");
            Item itemTest2 = new Item("TestOwner3", "TestId_3");
            BankVault trezor = new BankVault();
            trezor.AddItem("A1", itemTest);
            Assert.That(() => trezor.AddItem("A1", itemTest2), Throws.ArgumentException);
        }

        [Test]
        public void AddItemSameItemInTheSameCell()
        {
            Item itemTest = new Item("TestOwner3", "TestId_3");            
            BankVault trezor = new BankVault();
            trezor.AddItem("C1", itemTest);
            Assert.That(() => trezor.AddItem("C2", itemTest), Throws.InvalidOperationException);
        }
        [Test]
        public void AddItemRetursStringMessage()
        {
            BankVault trezor = new BankVault();
            Item itemTest = new Item("TestOwner", "TestId_1");            
            Assert.AreEqual($"Item:{itemTest.ItemId} saved successfully!", trezor.AddItem("A1", itemTest));
        }

        [Test]
        public void RemoveItemWithNotExistingCell()
        {
            BankVault trezor = new BankVault();
            Item itemTest = new Item("TestOwner", "TestId_1");
            Assert.That(() => trezor.RemoveItem("Test", itemTest), Throws.ArgumentException);
        }

        [Test]
        public void RemoveItemCellExistButItIsEmpty()
        {
            BankVault trezor = new BankVault();
            Item itemTest = new Item("TestOwner", "TestId_1");
            Assert.That(() => trezor.RemoveItem("A1", itemTest), Throws.ArgumentException);
        }
        [Test]
        public void RemoveItemCellExistItemExistReturnsString()
        {
            BankVault trezor = new BankVault();
            Item itemTest = new Item("TestOwner", "TestId_1");
            trezor.AddItem("A1", itemTest);
            Assert.AreEqual($"Remove item:{itemTest.ItemId} successfully!", trezor.RemoveItem("A1", itemTest));
        }
    }
}