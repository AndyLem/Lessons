using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class Teacher : IDBase, IID
    {
        public string Name;
        
        public Teacher() : base()
        {

        }

        public Teacher(string name)
            : this()
        {
            Name = name;
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                var arr = Storage.Data.Courses.ToArray();
                return from c in arr where c.TeacherId == ID select c;
            }
        }

        public void AddCourse(Course c)
        {
            if (Storage.Data.Courses.GetItem(c.ID) == null)
                Storage.Data.Courses.AddItem(c);
            c.TeacherId = ID;
        }

        public void RemoveCourse(Course c)
        {
            c.TeacherId = string.Empty;
        }
    }
}
