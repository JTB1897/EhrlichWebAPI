using System;
using System.ComponentModel.DataAnnotations;
using EhrlichWebAPI.Contracts;

namespace EhrlichWebAPI.Models
{
    public class User: IBaseModel
    {
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8), 
            RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*+\\/|!\"£$%^&*()#[\\]@~'?><,.=-_]).{6,}", ErrorMessage = "Password must be contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }          
    
}
