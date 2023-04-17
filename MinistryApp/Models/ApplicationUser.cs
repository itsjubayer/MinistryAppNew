using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string City { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }


        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        //[RegularExpression(@"^(\d{11})$", ErrorMessage = "Not a valid phone number")]
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile")]
        [MaxLength(20)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number is not valid")]
        public string Mobile { get; set; }


        
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        //[RegularExpression(@"^(\d{13})$", ErrorMessage = "NID is not valid")]
        //[RegularExpression("\d*", ErrorMessage = "NID must be numeric")]
        //[RegularExpression("^[0-9]{1,12}$", ErrorMessage = "...")]
        [Display(Name = "NID")]
        [MaxLength(20)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "NID is not valid")]
        public string NID { get; set; }
       
        public string ETIN { get; set; }


        [DisplayName("DOB")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; } = DateTime.Now;

        public string PassportNo { get; set; }        
        public string Per_Address { get; set; }        
        public string pre_Address { get; set; }
       
        public string UserRole { get; set; }


        public bool IsActive { get; set; }
       

        [DisplayName("Attachment")]
        [Column(TypeName = "nvarchar(55)")]
        public string Attachment { get; set; }

        [DisplayName("Image")]
        [Column(TypeName = "nvarchar(150)")]
        public string ProfilePicture { get; set; }


        [Required]
        [DisplayName("Create Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;



    }
}
