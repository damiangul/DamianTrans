using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Street { get; set; }
        [Required]
        [MaxLength(30)]
        public string Number { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(30)]
        public string PostCode { get; set; }
    }
}
