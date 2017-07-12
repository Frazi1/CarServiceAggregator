using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAccess.Repository.RepositoryFile
{
    public static class BinaryHelper
    {
        public static void Save<T>(string fileName, T data)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, data);
            }
        }

        public static T Load<T>(string fileName)
        {
            T result;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = (T) bf.Deserialize(fs);
            }
            return result;
        }
    }
}