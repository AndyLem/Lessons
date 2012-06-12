using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lessons.Model;

namespace ModelTester
{
    [TestClass]
    public class StorageTester
    {
        [TestMethod]
        public void StudentsEnum()
        {
            Assert.IsNotNull(Storage.Data.Students.GetEnumerator(), "Possibly TypedList.GetEnumerator() returned null");
        }
    }
}
