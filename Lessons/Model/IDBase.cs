using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class IDBase : IID
    {
        protected string _id;

        public IDBase()
        {
            _id = Guid.NewGuid().ToString();
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
