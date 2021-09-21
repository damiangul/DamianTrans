using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string Pesel { get; set; }
        public decimal Salary { get; set; }

        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Opinion> Opinions  { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }
    }
}
