using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

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

		[Inject]
		protected IJSRuntime JSRuntime { get; set; }

		private string strEmployeeId { get; set; }

		[Parameter]
		public bool Confirm { get; set; }
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			employee = EmployeeCRUD.FetchSingleEmployee(this.EmployeeId);

			string strTableName = nameof(employee.City);
			DropDownValues = EmployeeCRUD.FetchDropDownList(strTableName);
		}

		protected override void OnParametersSet()
		{
			this.strEmployeeId = this.EmployeeId;
		}

		protected override async void OnAfterRender(bool firstRender)
		{
			await this.JSRuntime.InvokeVoidAsync("addDatePicker");
			base.OnAfterRender(firstRender);
		}

		protected void UpdateEmployee()
		{
			EmployeeCRUD.EditEmployee(strEmployeeId, employee);
			this.NavigationManager.NavigateTo("listemployees");
		}

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}