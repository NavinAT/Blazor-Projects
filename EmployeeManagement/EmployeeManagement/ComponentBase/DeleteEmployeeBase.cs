using System.Threading.Tasks;
using EmployeeManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAppCRUD
{
	public class DeleteEmployeeBase : ComponentBase
	{
		#region Fields
		protected EmployeeInformation employee = new EmployeeInformation();
		#endregion

		#region Properties
		[Parameter]
		public string EmployeeId { get; set; }

		[Inject]
		protected NavigationManager NavigationManager { get; set; }

		[Inject]
		public EmployeeDetails EmployeeDetails { get; set; }

		[Inject]
		protected IJSRuntime IJSRuntime { get; set; }

		private string strEmployeeID { get; set; }
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			employee = EmployeeCRUD.FetchSingleEmployee(this.EmployeeId);
		}

		protected override void OnParametersSet()
		{
			this.strEmployeeID = this.EmployeeId;
		}

		protected async Task Delete()
		{
			await this.IJSRuntime.InvokeVoidAsync("DeleteConfirmation", this.strEmployeeID);

			this.EmployeeDetails.ListEmployee = null;
			//EmployeeCRUD.DeleteEmployee(this.strEmployeeID);
			this.NavigationManager.NavigateTo("listemployees");
		}

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}