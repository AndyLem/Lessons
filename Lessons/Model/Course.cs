using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class Course : IDBase, IID
    {
        public string Name;
        private string _univerId;
        private string _teacherId;

        public string TeacherId
        {
            get { return _teacherId; }
            set { _teacherId = value; }
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
            get { return _univerId; }
            set { _univerId = value; }
        }

        public University Univer
        {
            get
            {
                return Storage.Data.Univers[_univerId];
            }

        }

        public Course()
            : base()
        {
        }

        public Course(string name, University univer)
            : this()
        {
            Name = name;
            _univerId = univer.ID;
        }
    }
}
