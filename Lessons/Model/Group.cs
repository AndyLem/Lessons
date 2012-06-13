using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Lessons.Model
{
    public class Group : IDBase, IID
    {
        private string _univerID;

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
        public Group(string name)
            : this()
        {
            Name = name;
            _univerID = string.Empty;
        }

        public IEnumerable<Student> Students 
        {
            get
            {
                // all available students 
                var allStuds = Storage.Data.Students.GetEnumerator();
                return from stud in allStuds
                       where stud.GroupID == ID
                       select stud;
            }
        }


        /// <summary>
        /// Sets the link between this group and passed student.
        /// Also tries to add the student to the Storage if nessesary
        /// </summary>
        /// <param name="s">Student being linked</param>
        public void AddStudent(Student s)
        {
            if (Storage.Data.Students.GetItem(s.ID) == null)
                Storage.Data.Students.AddItem(s);
            s.GroupID = ID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void RemoveStudent(Student s)
        {
            s.GroupID = string.Empty;
        }
    }
}
