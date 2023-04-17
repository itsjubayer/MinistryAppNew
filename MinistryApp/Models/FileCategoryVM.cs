using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Models
{
    public class FileCategoryVM
    {
        [Key]
        public int Id { get; set; }

        [Column("FileCategoryName")]
        public string FileCategoryName { get; set; } = "";
        [Column("FileCategoryValue")]
        public string FileCategoryValue { get; set; } = "";

        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;

    }
}
