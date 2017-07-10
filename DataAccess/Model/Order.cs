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
        public Car Car { get; set; }

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