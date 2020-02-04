using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppCRUD
{
	public class EmployeeInformation
	{
		#region Properties
		public Guid EmployeeNumber { get; set; }

		[Required(ErrorMessage = "Name is Required")]
		[StringLength(40, ErrorMessage = "Name should be less than 40 characters")]
		public string EmployeeName { get; set; }

		[Required(ErrorMessage = "Department is Required")]
		public string Department { get; set; }
		public int Salary { get; set; }

		[Required(ErrorMessage = "Date of birth is required")]
		public DateTime DOB { get; set; }
		public string City { get; set; }
		#endregion
	}
}