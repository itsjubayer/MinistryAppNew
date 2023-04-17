using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        [Display(Name = "Role List")]
        public EnumRoleLists EnumRoleList { get; set; }
        public Department Department { get; set; }
    }

    public enum Department
    {
        SALES,
        FINANCE,
        ENGINEERING,
        MARKETING
    }



    public enum EnumRoleLists
    {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "Supervisor")]
        Supervisor,
        [Display(Name = "Chamber")]
        Chamber
    }

    public enum EnumRoleListsold
    {
        Admin =1,
        Supervisor=2,
        User=3,
        Treasurer=4
    }

}
