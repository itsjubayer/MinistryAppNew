using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Models
{
    public class TypesOfReportVM
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Report Type Name")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Report_Type_Name   { get; set; }

        [DisplayName("Frequency Of Report")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Frequency_Of_Report { get; set; } = "";

        [DisplayName("Start Date")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Start_Date { get; set; } = DateTime.Now;

        [DisplayName("Alert days")]
        [Required(ErrorMessage = "This field is required.")]
        public int AlertDays { get; set; } = 0;

        [DisplayName("Alert Frquency")]
        [Required(ErrorMessage = "This field is required.")]
        public int AlertFrquency { get; set; } = 0;

        [DisplayName("Remarks")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Remarks { get; set; }="";

        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;

        public FreqOfReport FreqOfReport { get; set; }

    }

    public enum FreqOfReport
    {
        [Display(Name = "Daily")]
        Daily,
        [Display(Name = "Weekly")]
        Weekly,
        [Display(Name = "Monthly")]
        Monthly,
        [Display(Name = "Yearly")]
        Yearly
    }


}
