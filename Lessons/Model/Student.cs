using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lessons.Model
{
    public class Student : IID
    {
        [XmlIgnore]
        protected string _id;

        [XmlElement(ElementName = "StudentName", IsNullable=false)]
        public string Name;

        public List<string> Urls;

        /// <summary>
        /// This constructor should be used only for deserialization
        /// </summary>
        public Student()
        {
            Urls = new List<string>();
        }

        public Student(string name) : this()
        {
            Name = name;
            _id = Guid.NewGuid().ToString();
        }

        public string ID
        {
            get { return _id; }
        }
    }
}
