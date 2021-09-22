using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Client
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
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Opinion> Opinions { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }
    }
}
