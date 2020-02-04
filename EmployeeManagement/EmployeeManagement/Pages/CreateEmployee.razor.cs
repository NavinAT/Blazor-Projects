using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAppCRUD;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EmployeeManagement.Pages
{
	public partial class CreateEmployee
	{
		#region Fields
		private List<string> DropDownValues;
		#endregion

		#region Properties
		private EmployeeInformation Employee { get; set; } = new EmployeeInformation();

		[Inject]
		public EmployeeManagement.EmployeeDetails EmployeeDetails { get; set; }

		[Inject]
		private NavigationManager NavigationManager { get; set; }

		//[Inject]
		//private IJSRuntime JSRuntime { get; set; }
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			const string strTableName = nameof(this.Employee.City);

			DropDownValues = EmployeeCRUD.FetchDropDownList(strTableName);
		}

		#endregion

		#region Privates
		//private async Task LoadStateAsync()
		//{
		//	Employee = await ProtectedLocalStorage.GetAsync<EmployeeInformation>("EmployeeData");
		//}

		private void CreateNewEmployee()
		{
			EmployeeCRUD.CreateEmployee(this.Employee);

			//ProtectedLocalStorage.SetAsync("EmployeeData", Employee);
			EmployeeDetails.ListEmployee = null;
			this.NavigationManager.NavigateTo("listemployees");
		}

		private void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}