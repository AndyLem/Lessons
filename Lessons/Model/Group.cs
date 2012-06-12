using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Lessons.Model
{
    public class Group : IID
    {
        protected string _id = string.Empty;
        private List<string> _studentsIds;

        public List<string> StudentsIds
        {
            get { return _studentsIds; }
            set { _studentsIds = value; }
        }

        public string Name;
            
        /// <summary>
        /// As usual, this ctor should be used only for serialization purposes. Do NOT generates an ID
        /// </summary>
        public Group()
        {
            _studentsIds = new List<string>();
        }

        /// <summary>
        /// Standard ctor for developers. It will generate a new ID for this group
        /// </summary>
        /// <param name="name">The name of the group</param>
        public Group(string name) : this()
        {
            _id = Guid.NewGuid().ToString();
            Name = name;
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public IEnumerable<Student> Students 
        {
            get
            {
                // all available students 
                var allStuds = Storage.Data.Students.GetEnumerator();

                // _studentsIds stores IDs of this group's students. 
                // So we need to join this two collections
                var thisGroupStuds = from stud in allStuds
                                     join ourStudId in _studentsIds
                                     on stud.ID equals ourStudId
                                     select stud;
                return thisGroupStuds; // there is a test for this
            }
        }

        public void AddStudent(Student s)
        {
            if (Storage.Data.Students.GetItem(s.ID) == null)
                Storage.Data.Students.AddItem(s);
            _studentsIds.Add(s.ID);
        }

        public void RemoveStudent(Student s)
        {
            _studentsIds.Remove(s.ID);
        }
    }
}
