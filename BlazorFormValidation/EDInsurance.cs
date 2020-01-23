using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorFormValidation
{
	public class EDInsurance
	{
		#region Properties
		public Guid InsuranceId { get; set; }

		[Required(ErrorMessage = "Insurance Name is Required")]
		[StringLength(10, ErrorMessage = "Name should be less than 10 characters")]
		public string InsuranceName { get; set; }

		[Required(ErrorMessage = "Caption is required")]
		public string Caption { get; set; }

		[Range(typeof(bool), "true", "true", ErrorMessage = "The Field is active must be checked")]
		public bool IsEmployeeExists { get; set; }

		[Required(ErrorMessage = "Date of birth is required")]
		public DateTime DOB { get; set; }

		[Required]
		public int Code { get; set; }
		#endregion
	}
}