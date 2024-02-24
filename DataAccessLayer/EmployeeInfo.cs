using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.DataAccessLayer
{
    public class EmployeeInfo
    {
		[Key]
		public long EmployeeID { get; set; }
		[Required(ErrorMessage = "Please Enter Your Name"), MaxLength(50)]
		[StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please Enter Date of Birth")]
		[DataType(DataType.Date)]
	
		public DateTime DOB { get; set; }
		[Required(ErrorMessage = "Please Enter MobileNumber")]
		[RegularExpression(@"^(\d{10})$", ErrorMessage = "Incorrect Phonenumber")]
		public long MobileNumber { get; set; }
		[Required(ErrorMessage = "Please Enter your Email")]
		[EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please Enter your Address")]
		public string Address { get; set; }


	}
}
