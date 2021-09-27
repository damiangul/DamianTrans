using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Models
{
    public class LoginClientWorkerDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
