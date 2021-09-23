using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int RoleId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfEmployment { get; set; }
        [Required]
        [MaxLength(11)]
        public string Pesel { get; set; }
        [Required]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Salary { get; set; }

        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Opinion> Opinions  { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }
    }
}
