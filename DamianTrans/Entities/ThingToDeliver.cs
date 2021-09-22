using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class ThingToDeliver
    {
        //Add pictures. Website should handle uploading images to the server. TODO!!!!!!! Workers should see what need to be delivered.
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Weight { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
