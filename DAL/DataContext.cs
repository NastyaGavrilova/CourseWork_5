using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataContext<T>
    {
        IDataProvider<T> DataProvider;

        public DataContext(int dataProvider)
        {
            DataProvider = new Serializer<T>();
        }
        public void Serialization(T objects)
        {
            DataProvider.Serialize(objects);
        }

        public T Deserialization()
        {
            return DataProvider.Deserialize();
        }
    }
}
