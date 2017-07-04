using System;

namespace DataAccess.Model
{
    [Serializable]
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int ManufactureYear { get; set; }
        public string Transmission { get; set; }
        public int EnginePower { get; set; }
        public string TaskName { get; set; }
        public DateTime TaskStarted { get; set; }
        public DateTime? TaskFinished { get; set; }
        public double Price { get; set; }
    }
}
