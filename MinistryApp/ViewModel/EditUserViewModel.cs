using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.ViewModel
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }

        [DisplayName("First Name")]
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }

        [DisplayName("Mobile")]
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "This field is required.")]
        public string Mobile { get; set; }
        [DisplayName("DOB")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [DisplayName("NID")]
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "This field is required.")]
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

        [DisplayName("Flat No")]
        [Column(TypeName = "nvarchar(250)")]
        public string Flat_No { get; set; }

        [DisplayName("User Role")]
        [Column(TypeName = "nvarchar(250)")]
        public string UserRole { get; set; }


        public string TenantValue { get; set; }

        [DisplayName("Type")]
        public bool Tenant { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Flat Owner")]
        public string FlatOwner { get; set; }




        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }

        public string ApartCodeName { get; set; }
    }
}
