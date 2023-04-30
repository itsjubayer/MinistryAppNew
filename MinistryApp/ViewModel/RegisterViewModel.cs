using MinistryApp.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        //[ValidEmailDomain(allowedDomain:"Pra.com", ErrorMessage="Email domain must be pra.com")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        /// <summary>
        /// Create Chamber
        /// </summary>
        public string ChamberName { get; set; } = string.Empty;
        public string TypesOfChambers { get; set; } = string.Empty;
        public string ChamberNo { get; set; } = string.Empty;
        public string Thana { get; set; } = string.Empty;
        public string Upzila { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string LicenseNo { get; set; } = string.Empty;

        [DisplayName("License Issue Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LicenseIssuedate { get; set; } = DateTime.Now;
        

        [DisplayName("License Revoke Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LicenseRevokeDate { get; set; } = DateTime.Now;
        
        public string LicenseStatus { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string LicenseAttachment { get; set; } = string.Empty;
        /// <summary>
        /// End Create Chamber
        /// </summary>


        public string City { get; set; }

        [DisplayName("First Name *")]
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "First Name field is required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name *")]
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Last Name field is required.")]
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
        [DisplayName("DOB")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        //[RegularExpression(@"^(\d{13})$", ErrorMessage = "NID is not Valid")]
        [Required(ErrorMessage = "You must provide a NID")]
        [Display(Name = "NID")]
        [MaxLength(20)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "NID is not valid")]
        public string NID { get; set; }

        [DisplayName("E-TIN")]
        [Column(TypeName = "nvarchar(25)")]
        public string ETIN { get; set; }

        [DisplayName("Passport")]
        [Column(TypeName = "nvarchar(25)")]
        public string PassportNo { get; set; }
        [DisplayName("Per-Address")]
        [Column(TypeName = "nvarchar(250)")]
        public string Per_Address { get; set; }

        [DisplayName("Pre-Address")]
        [Column(TypeName = "nvarchar(250)")]
        public string pre_Address { get; set; }

        
        [DisplayName("User Role")]
        [Column(TypeName = "nvarchar(250)")]
        public string UserRole { get; set; }

        

        
        public bool IsActive { get; set; }
        
        [DisplayName("Attachment")]
        [Column(TypeName = "nvarchar(55)")]
        public string Attachment { get; set; }

        [DisplayName("Image")]
        [Column(TypeName = "nvarchar(150)")]
        public string ProfilePicture { get; set; } = "no_picture.png";

        [Required]
        [DisplayName("Create Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;


    }
}
