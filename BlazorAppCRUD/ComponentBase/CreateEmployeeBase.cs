using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.ProtectedBrowserStorage;
using Microsoft.JSInterop;

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

		//[Inject]
		//protected ProtectedBrowserStorage localBrowserStorage { get; set; }

		[Inject]
		protected IJSRuntime JSRuntime { get; set; }
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			const string strTableName = nameof(employee.City);

			DropDownValues = EmployeeCRUD.FetchDropDownList(strTableName);
		}

		protected override async void OnAfterRender(bool firstRender)
		{
			//if(firstRender)
			//{
			//	await LoadStateAsync();
			//	StateHasChanged();
			//}

			await this.JSRuntime.InvokeVoidAsync("addDatePicker");
		}

		//private async Task LoadStateAsync()
		//{
		//	employee = await this.localBrowserStorage.GetAsync<EmployeeInformation>("EmployeeData");
		//}

		protected void CreateNewEmployee()
		{
			EmployeeCRUD.CreateEmployee(employee);

			//this.localBrowserStorage.SetAsync("EmployeeData", employee);

			this.NavigationManager.NavigateTo("listemployees");
		}

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}