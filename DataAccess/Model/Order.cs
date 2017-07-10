using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DataAccess.Model
{
    [Serializable]
    public class Order
    {
        [XmlIgnore, NonSerialized]
        private Customer _customer;

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


        ////TODO: Убрать эти поля
        //[XmlIgnore][value:NonSerialized]
        //public string CarBrand {
        //    get => Car.CarBrand;
        //    set => Car.CarBrand = value;
        //}

        //[XmlIgnore]
        //public string CarModel {
        //    get => Car.CarModel;
        //    set => Car.CarModel = value;
        //}

        //[XmlIgnore]
        //public string TransmissionType {
        //    get => Car.TransmissionType;
        //    set => Car.TransmissionType = value;
        //}

        //[XmlIgnore]
        //public int EnginePower {
        //    get => Car.EnginePower;
        //    set => Car.EnginePower = value;
        //}

        //[XmlIgnore]
        //public short ManufactureYear {
        //    get => Car.ManufactureYear;
        //    set => Car.ManufactureYear = value;
        //}

    }
}