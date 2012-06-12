using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lessons.Model;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace ModelTester
{
    [TestClass]
    public class GroupStudentTester
    {
        [TestMethod]
        public void TestIDs()
        {
            University newUni = new University("Best Uni ever");
            Assert.IsFalse(string.IsNullOrEmpty(newUni.ID), "Univer's constructor with parameters must generate an ID");

            Student newStud = new Student("Mr. Studoid");
            Assert.IsFalse(string.IsNullOrEmpty(newStud.ID), "Student's constructor with parameters must generate an ID");
            Group newGroup = new Group("Test Group", newUni);
            Assert.IsFalse(string.IsNullOrEmpty(newGroup.ID), "Group's constructor with parameters must generate an ID");
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
            Group tempGroup = new Group("TestGroup", new University("TestUni"));
            Student stud1 = new Student("Mr. First");
            Student stud2 = new Student("Mr. Second");
            Student stud3 = new Student("Mr. Third");
            tempGroup.AddStudent(stud1);
            Storage.Data.Students.AddItem(stud2);
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

        [TestMethod]
        public void SerializeStudent()
        {
            Student srcStud = new Student("Mr. Serializator");
            string tempFileName = Path.GetTempFileName();
            FileStream fs = File.Create(tempFileName);
            XmlSerializer ser = new XmlSerializer(typeof(Student));
            ser.Serialize(fs, srcStud);
            fs.Close();
            fs = File.OpenRead(tempFileName);
            Student newStud = (Student)ser.Deserialize(fs);
            fs.Close();
            File.Delete(tempFileName);
            Assert.AreEqual(srcStud.Name, newStud.Name, "Names expected to be equal");
            Assert.AreEqual(srcStud.ID, newStud.ID, "IDs expected to be equal");
        }

        [TestMethod]
        public void SerializeGroup()
        {
            Group srcGroup = new Group("Test Group", new University());
            Student stud = new Student("Mr. Stud");
            srcGroup.AddStudent(stud);
            
            string tempFileName = Path.GetTempFileName();
            FileStream fs = File.Create(tempFileName);
            XmlSerializer ser = new XmlSerializer(typeof(Group));
            ser.Serialize(fs, srcGroup);
            fs.Close();
            fs = File.OpenRead(tempFileName);
            Group newGroup = (Group)ser.Deserialize(fs);
            fs.Close();
            File.Delete(tempFileName);
            
            Assert.AreEqual(srcGroup.Name, newGroup.Name, "Names expected to be equal");
            Assert.AreEqual(srcGroup.ID, newGroup.ID, "IDs expected to be equal");
            Assert.AreEqual(srcGroup.Students.Count(), newGroup.Students.Count(), "Something wrong with studList serialization");

            Student savedMrStud = newGroup.Students.ElementAt(0);
            StringAssert.Equals(stud.Name, savedMrStud.Name);

            Storage.Data.Students.RemoveItem(stud);
        }
    }
}
