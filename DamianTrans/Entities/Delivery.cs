using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Delivery
    {
        public int Id { get; set; }
        public int? WorkerId { get; set; }
        public int? ClientId { get; set; }
        public int? CarId { get; set; }
        public DateTime DateOfTransport { get; set; }
        public int PriceForOneKm { get; set; }
        public decimal Distance { get; set; }
        public string WhereIsPackage { get; set; }
        public string WhereToGo { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }
        public virtual List<ThingToDeliver> ThingsToDeliver { get; set; }
        public virtual List<DeliveryStatus> DeliveryStatuses { get; set; }
    }
}
