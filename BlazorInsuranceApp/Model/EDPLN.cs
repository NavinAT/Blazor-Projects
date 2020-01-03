using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorInsuranceApp.Model
{
	public class EDPLN
	{
		#region Properties
		public Guid EDPLNId { get; set; }
		public Guid EDINSId { get; set; }

		public string Abbreviation { get; set; }

		[Required]
		public string ShortCaption { get; set; }

		[Required]
		public string Caption { get; set; }
		#endregion
	}
}