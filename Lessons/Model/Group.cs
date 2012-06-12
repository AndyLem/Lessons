using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Lessons.Model
{
    public class Group : IDBase, IID
    {
        private string _univerId;

        public string UniverId
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

        public string Name;
            
        /// <summary>
        /// As usual, this ctor should be used only for serialization purposes. Does NOT generates an ID
        /// </summary>
        public Group() : base()
        {
        }

        /// <summary>
        /// Standard ctor for developers. It will generate a new ID for this group
        /// </summary>
        /// <param name="name">The name of the group</param>
        public Group(string name, University univer) : this()
        {
            Name = name;
            _univerId = univer.ID;
        }

        public IEnumerable<Student> Students 
        {
            get
            {
                // all available students 
                var allStuds = Storage.Data.Students.GetEnumerator();
                return from stud in allStuds
                       where stud.GroupId == ID
                       select stud;
            }
        }

        public void AddStudent(Student s)
        {
            if (Storage.Data.Students.GetItem(s.ID) == null)
                Storage.Data.Students.AddItem(s);
            s.GroupId = ID;
        }

        public void RemoveStudent(Student s)
        {
            s.GroupId = string.Empty;
        }
    }
}
