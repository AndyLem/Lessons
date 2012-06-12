using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class Group : IID
    {
        protected string _id;
                
        public Group()
        {
            _id = Guid.NewGuid().ToString();
        }

        public string ID
        {
            get { return _id; }
        }

        public IEnumerable<Student> Students 
        {
            get
            {
                return null;
            }

        }
    }
}
