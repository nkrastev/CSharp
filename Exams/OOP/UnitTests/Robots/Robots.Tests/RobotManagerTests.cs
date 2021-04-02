using NUnit.Framework;

namespace Robots.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RobotClassCtorAndOnePropertyProbablyHaveToBeInDifferentTests()
        {
            Robot robot = new Robot("Pesho", 5);
            Assert.IsNotNull(robot);
            Assert.AreEqual(robot.MaximumBattery, 5);
        }
        [Test]
        public void CtorTest()
        {
            RobotManager manager = new RobotManager(10);
            Assert.IsNotNull(manager);
        }
        [Test]
        public void CapacityOfRobotManagerRegular()
        {
            RobotManager manager = new RobotManager(10);
            Assert.AreEqual(10, manager.Capacity);
        }
        [Test]
        public void CapacityOfRobotManagerExeption()
        {
            RobotManager manager = null;
            Assert.That(() => manager = new RobotManager(-10), Throws.ArgumentException);
        }
        [Test]
        public void CountOfRobotsGetter()
        {
            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);
            Robot robot2 = new Robot("Gosho", 7);
            manager.Add(robot1);
            manager.Add(robot2);
            Assert.AreEqual(2, manager.Count);
        }
        [Test]
        public void AddSameRobotExeption()
        {
            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);
            manager.Add(robot1);
            Assert.That(()=>manager.Add(robot1), Throws.InvalidOperationException);
        }
        [Test]
        public void AddRobotButNotEnoughtPlace()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot1 = new Robot("Pesho", 5);
            Robot robot2 = new Robot("Gosho", 7);
            manager.Add(robot1);
            Assert.That(() => manager.Add(robot2), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveNonExistingRobotExeption()
        {

            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);          
            manager.Add(robot1);
            Assert.That(() => manager.Remove("Gosho"), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveRegularRobot()
        {
            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);
            manager.Add(robot1);
            manager.Remove("Pesho");
            Assert.AreEqual(0, manager.Count);
        }
        [Test]
        public void WorkDecreaseBatteryRegular()
        {
            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);
            manager.Add(robot1);
            manager.Work("Pesho", "SomeJob", 1);
            Assert.AreEqual(4, robot1.Battery);
        }
        [Test]
        public void WorkWithNonExistingRobotException()
        {
            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);
            manager.Add(robot1);
            Assert.That(() => manager.Work("Gosho", "NonExistingJob", 4), Throws.InvalidOperationException);
        }
        [Test]
        public void WorkWithNotEnoughtBatteryExeption()
        {
            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);
            manager.Add(robot1);
            Assert.That(() => manager.Work("Pesho", "SomeJob", 6), Throws.InvalidOperationException);
        }
        [Test]
        public void ChargeNonExistingRobotExeption()
        {
            RobotManager manager = new RobotManager(10);
            Assert.That(() => manager.Charge("NonExistingRobot"), Throws.InvalidOperationException);
        }
        [Test]
        public void ChargeRobotIncreaseBattery()
        {
            RobotManager manager = new RobotManager(10);
            Robot robot1 = new Robot("Pesho", 5);
            manager.Add(robot1);
            manager.Work("Pesho", "SomeJob", 3);
            manager.Charge("Pesho");
            Assert.AreEqual(5, robot1.Battery);
        }

    }
}