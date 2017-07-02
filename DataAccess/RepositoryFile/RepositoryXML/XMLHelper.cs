using DataAccess.Model;
using System.IO;
using System.Xml.Serialization;
namespace DataAccess.RepositoryFile.RepositoryXML
{
    public static class XMLHelper
    {
        public static CustomersOrdersObject Load(string filePath)
        {
            CustomersOrdersObject result;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                XmlSerializer x = new XmlSerializer(typeof(CustomersOrdersObject));
                result = (CustomersOrdersObject)x.Deserialize(fs);
            }
            return result;
        }

        public static void Save(string filePath, CustomersOrdersObject data)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer x = new XmlSerializer(typeof(CustomersOrdersObject));
                x.Serialize(fs, data);
            }
        }
    }
}