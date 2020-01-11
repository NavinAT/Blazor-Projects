using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BlazorAppCRUD
{
	public class EditEmployeeBase : ComponentBase
	{
		#region Fields
		protected EmployeeInformation employee = new EmployeeInformation();
		protected List<string> DropDownValues;
		#endregion

		#region Properties
		[Parameter]
		public string EmployeeId { get; set; }

		[Inject]
		protected NavigationManager NavigationManager { get; set; }
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			employee = EmployeeCRUD.FetchSingleEmployee(this.EmployeeId);

			string strTableName = nameof(employee.City);
			DropDownValues = EmployeeCRUD.FetchDropDownList(strTableName);
		}

		protected void UpdateEmployee()
		{
			EmployeeCRUD.EditEmployee(this.EmployeeId, employee);
			this.NavigationManager.NavigateTo("listemployees");
		}

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}