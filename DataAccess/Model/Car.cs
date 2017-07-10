using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Serializable]
    public struct Car
    {
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
    }
}