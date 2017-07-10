using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DataAccess.Model
{
    [Serializable]
    public class Customer
    {
        //[NonSerialized]
        //[XmlIgnore]
        //private ICollection<Car> _cars = new List<Car>();

        public int CustomerId { get; set; }

        [Required]
        [StringLength(45)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(45)]
        public string Surname { get; set; }

        [StringLength(45)]
        public string Patronymic { get; set; }

        [Required]
        [Column(TypeName = "year")]
        public short BirthYear { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        //[Required]
        //public ICollection<Car> CarsCollection {
        //    get => _cars;
        //    set => _cars = value;
        //}
    }
}