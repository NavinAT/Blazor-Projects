using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorInsuranceApp
{
	public class EDINS
	{
		#region Properties
		public Guid EDINSId { get; set; }

		[Required]
		public int InsSubNr { get; set; }

		public string Abbreviation { get; set; }

		[Required]
		public string ShortCaption { get; set; }

		[Required]
		public string Caption { get; set; }

		[Required]
		public string InsuranceType { get; set; }
		#endregion
	}
}