using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAppCRUD
{
	public class CreateEmployeeBase : ComponentBase
	{
		#region Fields
		

		protected List<string> DropDownValues;
		#endregion

		#region Properties
		[Inject]
		protected NavigationManager NavigationManager { get; set; }

		[Inject]
		protected IJSRuntime JSRuntime { get; set; }
		#endregion

		#region Protecteds
		

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}