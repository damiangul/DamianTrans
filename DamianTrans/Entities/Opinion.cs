using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Entities
{
    public class Opinion
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? WorkerId { get; set; }
        public string EmployeeAssessment { get; set; }

        public virtual Client Client { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
