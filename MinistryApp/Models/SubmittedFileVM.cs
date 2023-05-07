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
    public class SubmittedFileVM
    {
        [Key]
        public int Id { get; set; }

        public int Chamber_Id { get; set; } = 0;
        //public virtual ApplicationUser ChamberPerson { get; set; }
        public int Report_Type_Id { get; set; }
        public virtual TypesOfReportVM TypesOfReport { get; set; }

        [DisplayName("Chamber")]
        [Column(TypeName = "nvarchar(50)")]
        public string chamber_username { get; set; }


        [DisplayName("Attachment")]
        [Column(TypeName = "nvarchar(50)")]
        public string Attachment { get; set; }

        [DisplayName("Submission Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Submission_Date { get; set; } = DateTime.Now;

        [DisplayName("DeadLine")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeadLine { get; set; } = DateTime.Now;

        [DisplayName("Reviewed Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReviewedDate { get; set; } = DateTime.Now;

        [DisplayName("File Submit Status")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string File_Submit_Status { get; set; }

        [DisplayName("Re-Submit Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReSubmitDate { get; set; } = DateTime.Now;

        [DisplayName("Feedback Note")]
        [Column(TypeName = "nvarchar(50)")]
        public string Feedback_Note { get; set; }

        [DisplayName("Feedback Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FeedbackDate { get; set; } = DateTime.Now;

        [DisplayName("Feedback By")]
        [Column(TypeName = "nvarchar(50)")]
        public string Feedback_By { get; set; }

        [DisplayName("CreatedBy")]
        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [DisplayName("Create Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [DisplayName("Active")]
        public bool IsActive { get; set; }


    }
}
