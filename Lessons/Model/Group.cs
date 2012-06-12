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
            _studentsIds.Add(s.ID);
        }

        public void RemoveStudent(Student s)
        {
            _studentsIds.Remove(s.ID);
        }
    }
}
