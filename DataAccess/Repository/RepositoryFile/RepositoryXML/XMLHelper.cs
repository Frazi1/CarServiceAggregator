using System.IO;
using System.Xml.Serialization;

namespace DataAccess.Repository.RepositoryFile
{
    public static class XmlHelper<T>
        where T : new()
    {
        public static T Load(string filePath)
        {
            T result;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                XmlSerializer x = new XmlSerializer(typeof(T));
                result = (T) x.Deserialize(fs);
            }
            return result;
        }

        public static void Save(string filePath, T data)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer x = new XmlSerializer(typeof(T));
                x.Serialize(fs, data);
            }
        }
    }
}