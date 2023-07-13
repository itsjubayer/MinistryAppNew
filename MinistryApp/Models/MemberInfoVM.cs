using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Models
{
    [Table("MemberInfo")]
    public class MemberInfoVM
    {
        [Key]
        public int Id { get; set; }
        public string ChamberId { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string MemberName { get; set; }
        
        [DisplayName("Address")]
        [Column(TypeName = "nvarchar(250)")]
        public string? Address { get; set; }

        public int Thana { get; set; }
        // public virtual UnionsVM UnionsVM { get; set; }
        public int Upzila { get; set; }
        //public virtual UpazilasVM UpazilasVM { get; set; }

        public int District { get; set; }
        //public virtual DistrictsVM DistrictsVM { get; set; }

        public int Division { get; set; }
        // public virtual DivisionsVM DivisionsVM { get; set; }

        public string Country { get; set; } = string.Empty;


        [Required(ErrorMessage = "field is required.")]
        [DisplayName("Status")]
        [Column(TypeName = "nvarchar(20)")]
        public string Status { get; set; }

        public string PostalCode { get; set; } = string.Empty;
        public string Tradelicense { get; set; } = string.Empty;
        public string NID { get; set; } = string.Empty;
        public string TIN { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Alternative_Phone { get; set; } = string.Empty;
        public string Alternative_Email { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Expiry Date field is required.")]
        [DisplayName("Expiry Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpiryDate { get; set; }

        [DisplayName("Entry Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EntryDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "field is required.")]
        [DisplayName("Designation")]
        [Column(TypeName = "nvarchar(20)")]
        public string Designation { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;
    }
}
