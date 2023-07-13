using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Ministry.Models
{
    public class NewsEventsVM
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("News Title")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        public string NewsTitle { get; set; }

        [DisplayName("News Description")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(550)")]
        public string NewsDescription { get; set; }



        [DisplayName("Image")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string ImageName { get; set; } = string.Empty;

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile Image { get; set; }

        [DisplayName("Publish Date")]
        [Column(TypeName = "DateTime")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [EnumDataType(typeof(LanguageType))]
        public LanguageType LanguageType { get; set; }


        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;
    }

    
}
