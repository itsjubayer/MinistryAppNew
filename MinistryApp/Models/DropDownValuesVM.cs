using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Models
{
    public class DropDownValuesVM
    {
        [Key]
        public int Id { get; set; }

        [Column("DropDownText")]
        public string DropDownText { get; set; } = string.Empty;

        [Column("DropDownValue")]
        public string DropDownValue { get; set; } = string.Empty;

        public int DropDownRef { get; set; } = 0;


        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;

        public EnumValueType EnumValueType { get; set; }
    }

    public enum EnumValueType
    {
        [Display(Name = "CHAMBER_TYPE")]
        CHAMBER_TYPE,
        [Display(Name = "DESIGNATION")]
        DESIGNATION
    }


}
