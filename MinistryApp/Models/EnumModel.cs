using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.Models
{
    [Table("tblEnum")]
    public class EnumModel
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [DisplayName("Value")]
        [Column(TypeName = "varchar(50)")]
        public string Value { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Text")]
        [Column(TypeName = "varchar(50)")]
        public String EnumText { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[DisplayName("Image")]
        //[Column(TypeName = "varchar(50)")]
        //public String imgLoc { get; set; }

        public EnumValueType EnumValueType { get; set; }

        [DisplayName("Code")]
        public string ApartCodeName { get; set; }

    }


    public enum EnumValueType
    {
        BILL_TYPE,
        BILL_FOR,
        FUND_TYPE,        
        CONTRACT,
        EMPLOYEE_TYPE,        
        BILL_FREQUENCY,        
        DESIGNATION,        
        MAINTENANCE_TYPE
    }

        //EXPENSE,
        //PAYMENT,
        //MEETING,
        //ROLL,
        //SERVICE,
        //MONTH,
        //EMPLOYEE_STATUS,
}
