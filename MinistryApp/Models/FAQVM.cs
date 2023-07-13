using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Models
{
    [Table("tblFAQ")]
    public class FAQVM
    {
        [Key]
        public int Id { get; set; } = 0;

        [DisplayName("FAQ Title")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        public string FaqTitle { get; set; }=string.Empty;

        [DisplayName("Description")]
        [Column(TypeName = "nvarchar(550)")]
        public string FaqDescription { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(250)")]
        public string EntryBy { get; set; } = string.Empty;

        [DisplayName("Date")]
        [Column(TypeName = "DateTime")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;


        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;

    }
}
