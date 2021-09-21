using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class DeliveryStatus
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateOfStatusChange { get; set; }
        public string? Note { get; set; }

        public virtual Delivery Delivery { get; set; }
        public virtual Status Status { get; set; }
    }
}
