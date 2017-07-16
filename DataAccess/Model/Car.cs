using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DataAccess.Model
{
    [Serializable]
    public class Car
    {
        private int _carId;

        [NonSerialized] private Customer _customer;

        public int CarId {
            get { return _carId; }
            set { _carId = value; }
        }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        public string CarBrand { get; set; }

        [Required]
        [StringLength(30)]
        public string CarModel { get; set; }

        [Required]
        [Column(TypeName = "year")]
        public short ManufactureYear { get; set; }

        [Required]
        [StringLength(20)]
        public string TransmissionType { get; set; }

        public int EnginePower { get; set; }

        [XmlIgnore]
        public Customer Customer {
            get { return _customer; }
            set { _customer = value; }
        }
    }
}