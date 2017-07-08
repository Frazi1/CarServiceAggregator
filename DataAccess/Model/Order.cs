using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DataAccess.Model
{
    [Serializable]
    public class Order
    {
        [XmlIgnore] [NonSerialized] private Customer _customer;

        public int OrderId { get; set; }

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

        [StringLength(45)]
        public string TaskName { get; set; }

        public DateTime? TaskStarted { get; set; }

        public DateTime? TaskFinished { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer {
            get => _customer;
            set => _customer = value;
        }
    }
}