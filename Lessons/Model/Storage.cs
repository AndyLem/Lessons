using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        private TypedList<University> _univers;

        public TypedList<University> Univers
        {
            get { return _univers; }
            set { _univers = value; }
        }

        private TypedList<Course> _courses;

        public TypedList<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        private TypedList<Teacher> _teachers;

        public TypedList<Teacher> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }

        private Storage()
        {
            _students = new TypedList<Student>();
            _groups = new TypedList<Group>();
            _univers = new TypedList<University>();
            _courses = new TypedList<Course>();
            _teachers = new TypedList<Teacher>();
        }

        internal void Save(string fileName)
        {
            _students.Save(fileName + ".students");
            _groups.Save(fileName + ".groups");
            _univers.Save(fileName + ".univers");
            _courses.Save(fileName + ".courses");
            _teachers.Save(fileName + ".teachers");
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
