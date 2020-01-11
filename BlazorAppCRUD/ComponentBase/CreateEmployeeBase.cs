using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BlazorAppCRUD
{
	public class CreateEmployeeBase : ComponentBase
	{
		#region Fields
		protected EmployeeInformation employee = new EmployeeInformation();
		protected List<string> DropDownValues;
		#endregion

		#region Properties
		[Inject]
		protected NavigationManager NavigationManager { get; set; }
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			const string strTableName = nameof(employee.City);

			DropDownValues = EmployeeCRUD.FetchDropDownList(strTableName);
		}

		protected void CreateNewEmployee()
		{
			EmployeeCRUD.CreateEmployee(employee);
			this.NavigationManager.NavigateTo("listemployees");
		}

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}