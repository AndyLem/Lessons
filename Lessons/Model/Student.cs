using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class Student : IID
    {
        protected string _id;

        public Student()
        {
            _id = Guid.NewGuid().ToString();
        }

        public string ID
        {
            get { return _id; }
        }
    }
}
