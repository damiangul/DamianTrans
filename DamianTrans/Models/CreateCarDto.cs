using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Models
{
    public class CreateCarDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string CarBrand { get; set; }
        [Required]
        [MaxLength(30)]
        public string CarModel { get; set; }
        [Required]
        public DateTime DateOfProduction { get; set; }
        [Required]
        [MaxLength(10)]
        public string LoadingCapacityInLiters { get; set; }
        [Required]
        public int MileageInKm { get; set; }
        [Required]
        public DateTime CarInspectionDate { get; set; }
    }
}
