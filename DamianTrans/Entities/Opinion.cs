using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Opinion
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? WorkerId { get; set; }
        [Required]
        public string EmployeeAssessment { get; set; }

        public virtual Client Client { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
