using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class Course : IDBase, IID
    {
        public string Name;
        private string _univerID;
        private string _teacherID;

        public string TeacherID
        {
            get { return _teacherID; }
            set { _teacherID = value; }
        }

        public Teacher Teacher
        {
            get
            {
                /// TODO
                return null;
            }
        }

        public string UniverID
        {
            get { return _univerID; }
            set { _univerID = value; }
        }

        public University Univer
        {
            get
            {
                return Storage.Data.Univers[_univerID];
            }

        }

        public Course()
            : base()
        {
        }

        public Course(string name)
            : this()
        {
            Name = name;
            _univerID = string.Empty;
        }


    }
}
