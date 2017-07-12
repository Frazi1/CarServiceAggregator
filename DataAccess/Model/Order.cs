﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DataAccess.Model
{
    [Serializable]
    public class Order
    {
        [NonSerialized] private Car _car;

        private int _carId;

        [NonSerialized] private Customer _customer;

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int CarId {
            get { return _carId; }
            set { _carId = value; }
        }


        [StringLength(45)]
        public string TaskName { get; set; }

        public DateTime? TaskStarted { get; set; }

        public DateTime? TaskFinished { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("CustomerId")]
        [XmlIgnore]
        public Customer Customer {
            get { return _customer; }
            set { _customer = value; }
        }

        [ForeignKey("CarId")]
        [XmlIgnore]
        public Car Car {
            get { return _car; }
            set { _car = value; }
        }
    }
}