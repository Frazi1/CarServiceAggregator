using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Serializable]
    public class Customer
    {
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
    }
}