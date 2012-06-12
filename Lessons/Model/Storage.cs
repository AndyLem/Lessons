using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    /// <summary>
    /// Classic Singleton implementation of the Storage.Data instance
    /// </summary>
    public sealed class Storage
    {
        private static Storage _data;
        
        public static Storage Data
        {
            get
            {
                if (_data == null)
                    _data = new Storage();
                return _data;
            }
        }

        private TypedList<Student> _students;

        public TypedList<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        private TypedList<Group> _groups;

        public TypedList<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        protected Storage()
        {
            _students = new TypedList<Student>();
            _groups = new TypedList<Group>();
        }

        internal void Save(string fileName)
        {
            _students.Save(fileName + ".students");
            _groups.Save(fileName + ".groups");
        }

        internal void ClearAll()
        {
            _students.Clear();
            _groups.Clear();
        }

        internal void Load(string fileName)
        {
            _students.Load(fileName + ".students");
            _groups.Load(fileName + ".groups");
        }
    }
}
