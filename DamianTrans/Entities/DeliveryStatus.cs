using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class DeliveryStatus
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public int StatusId { get; set; }
        [Required]
        public DateTime DateOfStatusChange { get; set; }
        public string? Note { get; set; }

        public virtual Delivery Delivery { get; set; }
        public virtual Status Status { get; set; }
    }
}
