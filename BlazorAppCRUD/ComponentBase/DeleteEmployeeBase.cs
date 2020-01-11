using Microsoft.AspNetCore.Components;

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
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			employee = EmployeeCRUD.FetchSingleEmployee(this.EmployeeId);
		}

		protected void Delete()
		{
			EmployeeCRUD.DeleteEmployee(this.EmployeeId);
			this.NavigationManager.NavigateTo("listemployees");
		}

		protected void Cancel()
		{
			this.NavigationManager.NavigateTo("listemployees");
		}
		#endregion
	}
}