using System.ComponentModel.DataAnnotations;

namespace MinistryApp.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
