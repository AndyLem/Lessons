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
        }

        public void AddGroup(Group group)
        {
            if (Storage.Data.Groups.GetItem(group.ID) == null)
                Storage.Data.Groups.AddItem(group);
            group.UniverId = ID;
        }

        public void RemoveGroup(Group group)
        {
            group.UniverId = string.Empty;
        }

        public IEnumerable<Group> Groups
        {
            get
            {
                var allGroups = Storage.Data.Groups.ToArray();
                return from g in allGroups where g.UniverId == ID select g;
            }
        }
    }
}
