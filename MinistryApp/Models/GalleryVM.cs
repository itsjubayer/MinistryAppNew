using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Microsoft.AspNetCore.Http;

namespace Ministry.Models
{
    public class GalleryVM
    {
        [Key]
        public int Id { get; set; } = 0;

        [DisplayName("Title")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; } = string.Empty;

        [DisplayName("Description")]
        [Column(TypeName = "nvarchar(550)")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Image")]
        [Column(TypeName = "nvarchar(550)")]
        public string ImageName { get; set; } = string.Empty;

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile Image { get; set; }

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
