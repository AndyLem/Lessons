using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Lessons.Model
{
    public class TypedList<T> where T : IID
    {
        protected Dictionary<string, T> dict = new Dictionary<string, T>();
        public TypedList()
        {
        }

        public T this[string ID]
        {
            get
            {
                return GetItem(ID);
            }
        }

        public T GetItem(string ID)
        {
            T item;
            if (dict.TryGetValue(ID, out item))
                return item;
            return default(T);
        }

        public T AddItem(T item)
        {
            if (!dict.ContainsKey(item.ID))
                dict.Add(item.ID, item);
            return item;
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (T t in range)
                AddItem(t);
        }

        public void RemoveItem(T item)
        {
            RemoveItem(item.ID);
        }

        public void RemoveItem(string ID)
        {
            try
            {
                dict.Remove(ID);
            }
            catch
            {
            }
        }

        public void Serialize(string fileName)
        {

        }

        public T[] ToArray()
        {
            return dict.Values.ToArray<T>();
        }

        public void Save(string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            List<T> lst = new List<T>(dict.Values);
            ser.Serialize(stream, lst);
            stream.Close();

        }

        public void Load(string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Open);
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            List<T> lst = new List<T>();
            lst = (List<T>)ser.Deserialize(stream);
            stream.Close();

            foreach (T obj in lst)
                AddItem(obj);
        }

        public IEnumerable<T> GetEnumerator()
        {
            return ToArray();
        }

        internal void Clear()
        {
            dict.Clear();
        }
    }
}
