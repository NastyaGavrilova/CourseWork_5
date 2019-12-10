using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DAL
{
    public class Serializer<T> : IDataProvider<T>
    {
        public void Serialize(T objects)
        {
            using (StreamWriter sw = new StreamWriter("JSON.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(sw, objects);
            }
        }

        public T Deserialize()
        {
            T objects;
            using (StreamReader sr = new StreamReader("JSON.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                objects = (T)serializer.Deserialize(sr, typeof(T));
            }
            return objects;
        }
    }
}
