using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class ClientOrder
    {
        //TODO!!! Server should handle images of things that are requested to deliver.
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }

        public virtual Client Client { get; set; }
    }
}
