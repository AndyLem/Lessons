using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons.Model
{
    /// <summary>
    /// Classic Singleton implementation of the Storage.Data instance
    /// </summary>
    public class Storage
    {
        protected static Storage _data;
        
        public static Storage Data
        {
            get
            {
                if (_data == null)
                    _data = new Storage();
                return _data;
            }
        }

        protected Storage()
        {

        }       
    }
}
