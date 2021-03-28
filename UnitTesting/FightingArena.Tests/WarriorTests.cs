//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior magician;

        private const string WARRIOR_NAME = "TheKnight";
        private const int WARRIOR_DAMAGE = 75;
        private const int WARRIOR_HP = 100;

        private const string MAGICIAN_NAME = "TheMagician";
        private const int MAGICIAN_DAMAGE = 80;
        private const int MAGICIAN_HP = 160;

        private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(WARRIOR_NAME, WARRIOR_DAMAGE, WARRIOR_HP);
            magician = new Warrior(MAGICIAN_NAME, MAGICIAN_DAMAGE, MAGICIAN_HP);            
        }

        [Test]
        public void ConstructorForWarrior()
        {
            Assert.IsNotNull(warrior);
        }
        
        //Test Warrior Properties
        [Test]
        [TestCase(null, 5,10)]
        [TestCase("", 5,10)]
        [TestCase("", 5,10)]
        [TestCase("TestName", 0,10)]
        [TestCase("TestName", -10,10)]
        [TestCase("TestName", 5,-10)]

        public void IfAnyPropertiesIsInvalid(
             string name,
             int damage,
             int hp)
        {
            Assert.That(() => new Warrior(name, damage, hp), Throws.ArgumentException);
        }

        //Test Attack Exceptions
        [Test]        
        public void AttackMethod_IfHpIsLowerThanMinimum_Exception()
        {
            Warrior testWarrior = new Warrior("N", 5, MIN_ATTACK_HP-1);            
            Assert.That(() => testWarrior.Attack(new Warrior("T", 4, 5)),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo("Your HP is too low in order to attack other warriors!")
            );
        }
        [Test]
        public void AttackMethod_IfHPOftheAttackerIsLowerThanMinimum()
        {
            Warrior testWarrior = new Warrior("N", 5, MIN_ATTACK_HP+10);
            Assert.That(() => testWarrior.Attack(new Warrior("T", 4, 5)),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!")
            );
        }
        [Test]
        public void AttackMethod_OurWarriorHasLowerHpThanAttackingWarriorDamage()
        {
            Warrior ourWarrior = new Warrior("N", 5, MIN_ATTACK_HP+1);
            Assert.That(() => ourWarrior.Attack(new Warrior("T", MIN_ATTACK_HP+5, MIN_ATTACK_HP + 10)),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo($"You are trying to attack too strong enemy")
            );
        }
        [Test]
        public void AttackMethod_DamageHasBeenDecreased()
        {
            Warrior ourWarrior = new Warrior("N", 10, MIN_ATTACK_HP +10);
            Warrior enemyWarrior = new Warrior("T", 10, MIN_ATTACK_HP + 10);
            //our warrior is attacked by the enemy one
            ourWarrior.Attack(enemyWarrior);
            Assert.AreEqual(MIN_ATTACK_HP, ourWarrior.HP);            
        }
        [Test]
        public void AttackMethod_IfOurWarriorDamageIsBiggerThanEnemyHP()
        {
            Warrior ourWarrior = new Warrior("N", MIN_ATTACK_HP+11, MIN_ATTACK_HP + 10);
            Warrior enemyWarrior = new Warrior("T", 10, MIN_ATTACK_HP + 10);
            //our warrior kill enemy
            ourWarrior.Attack(enemyWarrior);
            Assert.AreEqual(0, enemyWarrior.HP);
        }
        [Test]
        public void AttackMethod_DecreaseEnemyHP()
        {
            Warrior ourWarrior = new Warrior("N", 10, MIN_ATTACK_HP + 10);
            Warrior enemyWarrior = new Warrior("T", 10, MIN_ATTACK_HP + 10);
            //our warrior is attacked by the enemy one
            ourWarrior.Attack(enemyWarrior);
            Assert.AreEqual(MIN_ATTACK_HP, enemyWarrior.HP);
        }
    }
}