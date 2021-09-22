using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class ClientOrder
    {
        //TODO!!! Server should handle images of things that are requested to deliver.
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Weight { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual Client Client { get; set; }
    }
}
