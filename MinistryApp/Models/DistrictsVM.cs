using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Models
{
    public class DistrictsVM
    {
        [Key]
        public int Id { get; set; }
        public int Division_id { get; set; }

        


        [DisplayName("Name")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [DisplayName("Bangla name")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Bn_name { get; set; }

        [DisplayName("lat")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string lat { get; set; }

        [DisplayName("lon")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string lon { get; set; }

        [DisplayName("url")]
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string url { get; set; }

        //public List<UpazilasVM> UpazilaList { get; set; }

    }
}
