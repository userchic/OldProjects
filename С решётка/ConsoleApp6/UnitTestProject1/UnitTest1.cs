using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp6;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //    [TestMethod]
        //public void TestPerson0()
        //{
        //    Person p1 = new Person();
        //    Assert.AreEqual(new Person("Anonimous",0),p1);
        //}
        [TestMethod]
        public void TestPersonUsual()
        {
            Person p1 = new Person("Вася",10);
            Assert.AreEqual(p1, new Person("Вася",10));
        }
        [TestMethod]
        public void TestPersonCompar0()
        {
            Person p1 = new Person("Вася", 10);
            Person p2 = new Person("Вася", 10);
            Assert.AreEqual(p1.CompareTo(p2),0);
        }
        [TestMethod]
        public void TestPersonCompar1()
        {
            Person p1 = new Person("Вася", 10);
            Person p2 = new Person("Васенатор", 10);
            Assert.AreEqual(p1.CompareTo(p2), 1);
        }
        [TestMethod]
        public void TestPersonComparMinus1()
        {
            Person p1 = new Person("Васенатор", 10);
            Person p2 = new Person("СенаторВася", 10);
            Assert.AreEqual(p1.CompareTo(p2), -1);
        }
        [TestMethod]
        public void TestPersonClone()
        {
            Person p1 = new Person("Васенатор", 10);
            Person p2 = (Person)p1.Clone();
            Assert.AreEqual(new Person("КлонВасенатор", 10), p2);
        }
        [TestMethod]
        public void TestPersonShallowCopy()
        {
            Person p1 = new Person("Васенатор", 10);
            Person p2 = p1.ShallowCopy();
            Assert.AreEqual(new Person("Васенатор", 10), p2);
        }
        [TestMethod]
        public void TestPerson0()
        {
            Person p1 = new Person();
            Assert.AreEqual(p1.Division, 0);
        }
        [TestMethod]
        public void TestPersonEqual()
        {
            Person p1 = new Person("Васенатор", 10);
            Person p2 = new Person("Васенатор", 10);
            Assert.AreEqual(p1.Equals(p2),true);
        }
        [TestMethod]
        public void TestEngineerUsual()
        {
            Engineer p1 = new Engineer("Вася", 10,"Ремонт техники");
            Assert.AreEqual(p1, new Engineer("Вася", 10,"Ремонт техники"));
        }
        [TestMethod]
        public void TestEngineerCompar0()
        {
            Engineer p1 = new Engineer("Вася", 10,"Ремонт техники");
            Engineer p2 = new Engineer("Вася", 10,"Ремонт техники");
            Assert.AreEqual(p1.CompareTo(p2), 0);
        }
        [TestMethod]
        public void TestEngineerCompar1()
        {
            Engineer p1 = new Engineer("Вася", 10, "Ремонт техники");
            Engineer p2 = new Engineer("Васенатор", 10, "Ремонт техники");
            Assert.AreEqual(p1.CompareTo(p2), 1);
        }
        [TestMethod]
        public void TestEngineerComparMinus1()
        {
            Engineer p1 = new Engineer("Васенатор", 10, "Ремонт техники");
            Engineer p2 = new Engineer("СенаторВася", 10, "Ремонт техники");
            Assert.AreEqual(p1.CompareTo(p2), -1);
        }
        [TestMethod]
        public void TestEngineerClone()
        {
            Engineer p1 = new Engineer("Васенатор", 10, "Ремонт техники");
            Engineer p2 = (Engineer)p1.Clone();
            Assert.AreEqual(new Engineer("КлонВасенатор", 10, "Ремонт техники"), p2);
        }
        [TestMethod]
        public void TestEngineerShallowCopy()
        {
            Engineer p1 = new Engineer("Васенатор", 10, "Ремонт техники");
            Engineer p2 = (Engineer)p1.ShallowCopy();
            Assert.AreEqual(new Engineer("Васенатор", 10, "Ремонт техники"), p2);
        }
        [TestMethod]
        public void TestEngineer0()
        {
            Engineer p1 = new Engineer();
            Assert.AreEqual(p1.Division, 0);
        }
        [TestMethod]
        public void TestEngineerEqual()
        {
            Engineer p1 = new Engineer("Васенатор", 10, "Ремонт техники");
            Engineer p2 = new Engineer("Васенатор", 10, "Ремонт техники");
            Assert.AreEqual(p1.Equals(p2), true);
        }
        [TestMethod]
        public void TestWorkerUsual()
        {
            Worker p1 = new Worker("Вася", 10,"переводчик");
            Assert.AreEqual(p1, new Worker("Вася", 10, "переводчик"));
        }
        [TestMethod]
        public void TestWorkerCompar0()
        {
            Worker p1 = new Worker("Вася", 10, "переводчик");
            Worker p2 = new Worker("Вася", 10, "переводчик");
            Assert.AreEqual(p1.CompareTo(p2), 0);
        }
        [TestMethod]
        public void TestWorkerCompar1()
        {
            Worker p1 = new Worker("Вася", 10, "переводчик");
            Worker p2 = new Worker("Васенатор", 10, "переводчик");
            Assert.AreEqual(p1.CompareTo(p2), 1);
        }
        [TestMethod]
        public void TestWorkerComparMinus1()
        {
            Worker p1 = new Worker("Васенатор", 10, "переводчик");
            Worker p2 = new Worker("СенаторВася", 10, "переводчик");
            Assert.AreEqual(p1.CompareTo(p2), -1);
        }
        [TestMethod]
        public void TestWorkerClone()
        {
            Worker p1 = new Worker("Васенатор", 10, "переводчик");
            Worker p2 = (Worker)p1.Clone();
            Assert.AreEqual(new Worker("КлонВасенатор", 10, "переводчик"), p2);
        }
        [TestMethod]
        public void TestWorkerShallowCopy()
        {
            Worker p1 = new Worker("Васенатор", 10, "переводчик");
            Worker p2 = (Worker)p1.ShallowCopy();
            Assert.AreEqual(new Worker("Васенатор", 10, "переводчик"), p2);
        }
        [TestMethod]
        public void TestWorker0()
        {
            Worker p1 = new Worker();
            Assert.AreEqual(p1.Division, 0);
        }
        [TestMethod]
        public void TestWorkerEqual()
        {
            Worker p1 = new Worker("Васенатор", 10, "переводчик");
            Worker p2 = new Worker("Васенатор", 10, "переводчик");
            Assert.AreEqual(p1.Equals(p2), true);
        }
        [TestMethod]
        public void TestArmyManUsual()
        {
            ArmyMan p1 = new ArmyMan("Вася", 10, 30);
            Assert.AreEqual(p1, new ArmyMan("Вася", 10, 30));
        }
        [TestMethod]
        public void TestArmyManCompar0()
        {
            ArmyMan p1 = new ArmyMan("Вася", 10, 30);
            ArmyMan p2 = new ArmyMan("Вася", 10, 30);
            Assert.AreEqual(p1.CompareTo(p2), 0);
        }
        [TestMethod]
        public void TestArmyManCompar1()
        {
            ArmyMan p1 = new ArmyMan("Вася", 10, 30);
            ArmyMan p2 = new ArmyMan("Васенатор", 10, 30);
            Assert.AreEqual(p1.CompareTo(p2), 1);
        }
        [TestMethod]
        public void TestArmyManComparMinus1()
        {
            ArmyMan p1 = new ArmyMan("Васенатор", 10, 30);
            ArmyMan p2 = new ArmyMan("СенаторВася", 10, 30);
            Assert.AreEqual(p1.CompareTo(p2), -1);
        }
        [TestMethod]
        public void TestArmyManClone()
        {
            ArmyMan p1 = new ArmyMan("Васенатор", 10, 30);
            ArmyMan p2 = (ArmyMan)p1.Clone();
            Assert.AreEqual(new ArmyMan("КлонВасенатор", 10, 30), p2);
        }
        [TestMethod]
        public void TestArmyManShallowCopy()
        {
            ArmyMan p1 = new ArmyMan("Васенатор", 10, 30);
            ArmyMan p2 = (ArmyMan)p1.ShallowCopy();
            Assert.AreEqual(new ArmyMan("Васенатор", 10, 30), p2);
        }
        [TestMethod]
        public void TestArmyMan0()
        {
            ArmyMan p1 = new ArmyMan();
            Assert.AreEqual(p1.Division, 0);
        }
        [TestMethod]
        public void TestArmyManEqual()
        {
            ArmyMan p1 = new ArmyMan("Васенатор", 10,30);
            ArmyMan p2 = new ArmyMan("Васенатор", 10, 30);
            Assert.AreEqual(p1.Equals(p2), true);
        }
        [TestMethod]
        public void TestEnemyArmyManUsual()
        {
            EnemyArmyMan p1 = new EnemyArmyMan("Вася", 10);
            Assert.AreEqual(p1, new EnemyArmyMan("Вася", 10));
        }
        [TestMethod]
        public void TestEnemyArmyManCompar0()
        {
            EnemyArmyMan p1 = new EnemyArmyMan("Вася", 10);
            EnemyArmyMan p2 = new EnemyArmyMan("Вася", 10);
            Assert.AreEqual(p1.CompareTo(p2), 0);
        }
        [TestMethod]
        public void TestEnemyArmyManCompar1()
        {
            EnemyArmyMan p1 = new EnemyArmyMan("Вася", 10);
            EnemyArmyMan p2 = new EnemyArmyMan("Васенатор", 10);
            Assert.AreEqual(p1.CompareTo(p2), 1);
        }
        [TestMethod]
        public void TestEnemyArmyManComparMinus1()
        {
            EnemyArmyMan p1 = new EnemyArmyMan("Васенатор", 10);
            EnemyArmyMan p2 = new EnemyArmyMan("СенаторВася", 10);
            Assert.AreEqual(p1.CompareTo(p2), -1);
        }
        [TestMethod]
        public void TestEnemyArmyManClone()
        {
            EnemyArmyMan p1 = new EnemyArmyMan("Васенатор", 10);
            EnemyArmyMan p2 = (EnemyArmyMan)p1.Clone();
            Assert.AreEqual(new EnemyArmyMan("КлонВасенатор", 10), p2);
        }
        [TestMethod]
        public void TestEnemyArmyManShallowCopy()
        {
            EnemyArmyMan p1 = new EnemyArmyMan("Васенатор", 10);
            EnemyArmyMan p2 = p1.ShallowCopy();
            Assert.AreEqual(new EnemyArmyMan("Васенатор", 10), p2);
        }
        [TestMethod]
        public void TestEnemyArmyMan0()
        {
            EnemyArmyMan p1 = new EnemyArmyMan();
            Assert.AreEqual(p1.EnemyDivision, 0);
        }
        [TestMethod]
        public void TestEnemyArmyManEqual()
        {
            EnemyArmyMan p1 = new EnemyArmyMan("Васенатор", 10);
            EnemyArmyMan p2 = new EnemyArmyMan("Васенатор", 10);
            Assert.AreEqual(p1.Equals(p2), true);
        }
    }
}
