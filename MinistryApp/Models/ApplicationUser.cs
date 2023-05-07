using Microsoft.AspNetCore.Identity;
using Ministry.Models;
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
       
        /// <summary>
        /// Create Chamber
        /// </summary>
        public string ChamberName { get; set; } = string.Empty;
        public string TypesOfChambers { get; set; } = string.Empty;
        public string ChamberNo { get; set; } = string.Empty;
        public int Thana { get; set; }
       // public virtual UnionsVM UnionsVM { get; set; }
        public int Upzila { get; set; }
        //public virtual UpazilasVM UpazilasVM { get; set; }

        public int District { get; set; }
        //public virtual DistrictsVM DistrictsVM { get; set; }

        public int Division { get; set; }
       // public virtual DivisionsVM DivisionsVM { get; set; }

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
        /// 

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Mobile")]
        [MaxLength(20)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number is not valid")]
        public string Mobile { get; set; }
        
        
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

        //[DisplayName("Active")]
        //public bool IsActive { get; set; }

    }
}
