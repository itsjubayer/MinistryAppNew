using MinistryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Models
{
    [Table("tblFiles")]
    public class FileModelVM
    {
        [Key]
        public int Id { get; set; }

        [Column("FileName")]
        public string FileName { get; set; } = "";

        [Column("FilePath")]
        public string FilePath { get; set; }

        [DisplayName("Attachment")]
        [Column(TypeName = "nvarchar(50)")]
        public string Attachment { get; set; }



        [DisplayName("FileType")]
        [Column(TypeName = "nvarchar(250)")]
        public string? FileType { get; set; }

        [DisplayName("FileCategory")]
        [Required(ErrorMessage = "Type field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        public string? FileCategory { get; set; }

        [Required(ErrorMessage = "Dateline field is required.")]
        [DisplayName("Date line")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateLine { get; set; }

        [Required(ErrorMessage = "field is required.")]
        [DisplayName("SubmitStatus")]
        [Column(TypeName = "nvarchar(250)")]
        public string SubmitStatus { get; set; }

        [Required(ErrorMessage = "field is required.")]
        [DisplayName("Resonsible Person")]
        [Column(TypeName = "nvarchar(250)")]
        public string ResonsiblePerson { get; set; } = "";
        

        [DisplayName("CreatedBy")]
        [Column(TypeName = "varchar(250)")]
        public string CreatedBy { get; set; }


        [Required]
        [Column(TypeName = "DateTime")]
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }


        [DisplayName("SubmittedBy")]
        [Column(TypeName = "varchar(250)")]
        public string SubmittedBy { get; set; }

        [Column(TypeName = "DateTime")]
        [Display(Name = "Submitted Date")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SubmittedDate { get; set; }


        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public ApplicationUser application_users { get; set; }
    }
}
