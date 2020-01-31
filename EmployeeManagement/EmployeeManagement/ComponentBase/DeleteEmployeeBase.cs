using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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
			var bConfirm = await this.IJSRuntime.InvokeAsync<bool>("DeleteConfirmation");
			if(bConfirm)
			{
				EmployeeCRUD.DeleteEmployee(strEmployeeID);
				this.NavigationManager.NavigateTo("listemployees");
			}
		}

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}