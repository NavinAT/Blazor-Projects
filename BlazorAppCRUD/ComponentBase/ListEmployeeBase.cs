using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BlazorAppCRUD
{
	public class ListEmployeeBase : ComponentBase
	{
		#region Fields
		protected List<EmployeeInformation> lstEmployees;
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			lstEmployees = EmployeeCRUD.FetchEmployees();
		}

		#endregion
	}
}