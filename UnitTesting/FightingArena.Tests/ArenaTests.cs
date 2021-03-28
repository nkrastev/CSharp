//using FightingArena;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private List<Warrior> warriors;        

        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void ConstructorArena()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena);            
        }
        [Test]
        public void WarriorCounterCorrectValue()
        {
            Arena arena = new Arena();
            Assert.AreEqual(0, arena.Warriors.Count);
        }
        [Test]
        public void MethodEnroll_AddWarriorToTheArena()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("T", 10, 10));
            Assert.AreEqual(1, arena.Warriors.Count);
        }
        [Test]
        public void MethodEnroll_AddExistingWarrior_ThrowException()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("T", 10, 10));
            Assert.That(() => arena.Enroll(new Warrior("T", 10, 10)),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo("Warrior is already enrolled for the fights!"));
        }
        [Test]
        public void PropertyArenaCountValue()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("T", 10, 10));
            arena.Enroll(new Warrior("P", 10, 10));
            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        [TestCase("MissingName", "Pesho")]
        [TestCase("Pesho", "MissingName")]
        public void MethodFight_ExceptionCases(string attackerName, string defenderName)
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Pesho", 10, 10));
            Assert.That(() => 
            arena.Fight(attackerName, defenderName), Throws.InvalidOperationException);
        }

        [Test]
        public void MethodFight_ExistingWarriors_ChangeValues()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Pesho", 10, 50));
            arena.Enroll(new Warrior("Gosho", 10, 50));
            arena.Fight("Pesho", "Gosho");

            Warrior defender = arena.Warriors
                .FirstOrDefault(w => w.Name == "Pesho");

            Assert.AreEqual(40, defender.HP);
        }

        
    }
}
