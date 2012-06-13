using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class University : IDBase, IID
    {
        public string Name;
                
        public University() : base()
        {
        }

        public University(string name) : this()
        {
            Name = name;
            Storage.Data.Univers.AddItem(this);
        }

        /// <summary>
        /// Sets the link between this university and passed group. 
        /// Also tries to add a group to the Storage if nessesary
        /// </summary>
        /// <param name="group">Group being linked to the university</param>
        public void AddGroup(Group group)
        {
            if (Storage.Data.Groups.GetItem(group.ID) == null)
                Storage.Data.Groups.AddItem(group);
            group.UniverID = ID;
        }

        /// <summary>
        /// Removes the link to the group.
        /// Group stays in the Storage
        /// </summary>
        /// <param name="group"></param>
        public void RemoveGroup(Group group)
        {
            group.UniverID = string.Empty;
        }

        public IEnumerable<Group> Groups
        {
            get
            {
                var allGroups = Storage.Data.Groups.ToArray();
                return from g in allGroups where g.UniverID == ID select g;
            }
        }


        /// <summary>
        /// Sets the link between this university and passed course. 
        /// Also tries to add a course to the Storage if nessesary
        /// </summary>
        /// <param name="group">Course being linked to the university</param>
        public void AddCourse(Course course)
        {
            if (Storage.Data.Courses.GetItem(course.ID) == null)
                Storage.Data.Courses.AddItem(course);
            course.UniverID = ID;
        }

        /// <summary>
        /// Removes the link to the course.
        /// Course stays in the Storage
        /// </summary>
        /// <param name="group"></param>
        public void RemoveCourse(Course course)
        {
            course.UniverID = string.Empty;
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                var allCourses = Storage.Data.Courses.ToArray();
                return from c in allCourses where c.UniverID == ID select c;
            }
        }
    }
}
