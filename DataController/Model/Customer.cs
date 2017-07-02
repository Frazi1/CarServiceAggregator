using System;

namespace DataAccess.Model
{
    [Serializable]
    public class Customer
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int BirthYear{ get; set; }
        public string PhoneNumber { get; set; } // Придумать структуру для номера телефона
    }
}
