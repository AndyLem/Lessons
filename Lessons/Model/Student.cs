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

        protected string _groupID;

        public string GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        public Group Group
        {
            get
            {
                return Storage.Data.Groups[_groupID];
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
