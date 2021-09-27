using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Models
{
    public class RegisterClientDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("PasswordHash", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(30)]
        public string Street { get; set; }
        [Required]
        [MaxLength(30)]
        public string Number { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(30)]
        public string PostCode { get; set; }
    }
}

