using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lessons.Model;

namespace ModelTester
{
    [TestClass]
    public class GroupStudent
    {
        [TestMethod]
        public void TestNewIDs()
        {
            Group newGroup = new Group();
            Assert.IsFalse(string.IsNullOrEmpty(newGroup.ID));
            Student newStud = new Student();
            Assert.IsFalse(string.IsNullOrEmpty(newStud.ID));
        }

        [TestMethod]
        public void TestStudList()
        {
            Group newGroup = new Group();
            Assert.IsNotNull(newGroup.Students);
        }

        [TestMethod]
        public void TypedListEnum()
        {
            IEnumerable<Student> enumerableStudents = Storage.Data.Students.GetEnumerator();
            Assert.IsNotNull(enumerableStudents);
        }

        [TestMethod]
        public void StudentsOfGroup()
        {
            Group tempGroup = new Group();
            Student stud1 = new Student();
            Student stud2 = new Student();
            Student stud3 = new Student();
            Storage.Data.Students.AddItem(stud1);
            Storage.Data.Students.AddItem(stud2);
            Storage.Data.Students.AddItem(stud3);

            tempGroup.AddStudent(stud1);
            tempGroup.AddStudent(stud3);
            var resEnum = tempGroup.Students;
            var arr = resEnum.ToArray();
            Assert.AreEqual(2, arr.Length, "Two students expected to be in the group");
            Assert.AreEqual(stud1.ID, arr[0].ID, "There should be stud1");
            Assert.AreEqual(stud3.ID, arr[1].ID, "There should be stud3");

            Storage.Data.Students.RemoveItem(stud1);
            Storage.Data.Students.RemoveItem(stud2);
            Storage.Data.Students.RemoveItem(stud3);
        }
    }
}
