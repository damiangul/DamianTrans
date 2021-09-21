using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public DateTime DateOfProduction { get; set; }
        public string LoadingCapacityInLiters { get; set; }
        public int MileageInKm { get; set; }
        public DateTime CarInspectionDate { get; set; }

        public virtual List<Delivery> Deliveries { get; set; }
    }
}
