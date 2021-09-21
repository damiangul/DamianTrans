using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Opinion> Opinions { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }
    }
}
