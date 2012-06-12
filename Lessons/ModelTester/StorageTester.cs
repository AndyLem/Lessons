using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lessons.Model;
using System.IO;

namespace ModelTester
{
    [TestClass]
    public class StorageTester
    {
        protected static Group testGroup;
        protected static University testUniver;

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            testUniver = new University("Test Uni");
            testGroup = new Group("TestGroup", testUniver);
            testGroup.AddStudent(new Student("Mr. Brilliant"));
            testGroup.AddStudent(new Student("Mr. Diamond"));
            testGroup.AddStudent(new Student("Mr. Carbone"));
            Storage.Data.Groups.AddItem(testGroup);
        }
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public void StudentsEnum()
        {
            Assert.IsNotNull(Storage.Data.Students.GetEnumerator(), "Possibly TypedList.GetEnumerator() returned null");
        }

        [TestMethod]
        public void SerializationTest()
        {
            Assert.AreEqual(3, Storage.Data.Students.ToArray().Length, "Students list was not initialized");
            Assert.AreEqual(1, Storage.Data.Groups.ToArray().Length, "Groups list was not initialized");

            string tempFileName = Path.GetTempFileName();
            Storage.Data.Save(tempFileName);
            Storage.Data.ClearAll();
            Assert.AreEqual(0, Storage.Data.Students.ToArray().Length, "Students list in the Storage is not empty");
            Assert.AreEqual(0, Storage.Data.Groups.ToArray().Length, "Groups list in the Storage is not empty");
            Storage.Data.Load(tempFileName);
            Assert.AreEqual(3, Storage.Data.Students.ToArray().Length, "Students list was not deserialized");
            Assert.AreEqual(1, Storage.Data.Groups.ToArray().Length, "Groups list was not deserialized");
            Group newGroup = Storage.Data.Groups.ToArray()[0];
            Assert.AreEqual(testGroup.ID, newGroup.ID, "Group ID was not deserialized properly");

            File.Delete(tempFileName);
        }
    }
}
