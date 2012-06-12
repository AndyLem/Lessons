using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class Group : IID
    {
        protected string _id;
        protected List<string> _studentsIds;
                
        public Group()
        {
            _id = Guid.NewGuid().ToString();
            _studentsIds = new List<string>();
        }

        public string ID
        {
            get { return _id; }
        }

        public IEnumerable<Student> Students 
        {
            get
            {
                /// TODO: temporaty solution. need to replace with the search 
                /// by students giuds for this group
                //return Storage.Data.EnumStudents();

                var allStuds = Storage.Data.Students.GetEnumerator();
                var thisGroupStuds = from stud in allStuds
                                     join ourStudId in _studentsIds
                                     on stud.ID equals ourStudId
                                     select stud;
                return thisGroupStuds;
            }
        }

        public void AddStudent(Student s)
        {
            _studentsIds.Add(s.ID);
        }

        public void RemoveStudent(Student s)
        {
            _studentsIds.Remove(s.ID);
        }
    }
}
