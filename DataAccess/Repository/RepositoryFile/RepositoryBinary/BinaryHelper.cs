using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataAccess.Model;

namespace DataAccess.Repository.RepositoryFile
{
    public static class BinaryHelper
    {
        public static void Save(string fileName, CustomersOrdersObject data)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, data);
            }
        }

        public static CustomersOrdersObject Load(string fileName)
        {
            //TODO: Добавить обработку исключений
            CustomersOrdersObject result;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = (CustomersOrdersObject) bf.Deserialize(fs);
            }
            return result;
        }
    }
}