using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lessons.Model
{
    public class Student : IDBase, IID
    {
        public string Name;

        public List<string> Urls;

        protected string _groupId;

        public string GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public Group Group
        {
            get
            {
                return Storage.Data.Groups[_groupId];
            }
        }

        /// <summary>
        /// This constructor should be used only for deserialization
        /// </summary>
        public Student() : base()
        {
            Urls = new List<string>();
        }

        public Student(string name) : this()
        {
            Name = name;
        }
    }
}
