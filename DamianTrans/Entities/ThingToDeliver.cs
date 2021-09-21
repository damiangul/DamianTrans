using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class ThingToDeliver
    {
        //Add pictures. Website should handle uploading images to the server. TODO!!!!!!! Workers should see what need to be delivered.
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
