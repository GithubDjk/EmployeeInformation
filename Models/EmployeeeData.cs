using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeInformation.Models
{
    public class EmployeeeData
    {
        [Key]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int?  EmployeeParentId { get; set; }
        [Required(ErrorMessage ="Please Enter your Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter your Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter 8 digit long Password")]
        [MinLength(8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter your Role in Company")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Please choose your date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }

    }
}
