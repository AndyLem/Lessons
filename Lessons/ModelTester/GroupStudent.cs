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

    }
}
