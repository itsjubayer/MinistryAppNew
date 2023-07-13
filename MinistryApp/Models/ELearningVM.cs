using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Ministry.Models
{
    public class ELearningVM
    {
        [Key]
        public int Id { get; set; }

        //[DisplayName("Language")]
        //[Required(ErrorMessage = "This field is required.")]
        //[Column(TypeName = "nvarchar(25)")]
        //public string LanguageType { get; set; } = string.Empty;

        [DisplayName("Title")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; } = string.Empty;

        [DisplayName("Description")]
        [Column(TypeName = "nvarchar(550)")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("URL")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        public string VDOUrl { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(250)")]
        public string CreatedBy { get; set; } = string.Empty;

        [DisplayName("CreateDate")]
        [Column(TypeName = "DateTime")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;

        [EnumDataType(typeof(LanguageType))]
        public LanguageType LanguageType { get; set; }

    }

    public enum LanguageType
    {
        Bangla = 1,
        English = 2
    }
}
