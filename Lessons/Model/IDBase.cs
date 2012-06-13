using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    public class IDBase : IID
    {
        protected string _ID;

        public IDBase()
        {
            _ID = Guid.NewGuid().ToString();
        }

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
