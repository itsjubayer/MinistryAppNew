using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ministry.Models
{
    public class JobVM
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Job Title")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        public string JobTitle { get; set; }

        [DisplayName("Job Description")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(550)")]
        public string JobDescription { get; set; }

       

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
        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;

    }
}
