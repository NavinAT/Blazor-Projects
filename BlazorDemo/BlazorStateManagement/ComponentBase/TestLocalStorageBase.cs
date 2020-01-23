using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorStateManagement
{
	public class TestLocalStorageBase : ComponentBase
	{
		#region Fields
		protected Insurance _insurance;
		#endregion

		#region Properties
		[Inject]
		protected IJSRuntime IjsRuntime { get; set; }
		#endregion

		#region Protecteds
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if(firstRender)
			{
				await LoadStateAsync();
				StateHasChanged();
			}
		}

		protected void SetInsuranceDetails()
		{
			_insurance = new Insurance
			             {
				             InsuranceName = "LIC",
				             Caption = "Life Insurance Corporation",
				             InsuranceCode = 100013
			             };

			this.IjsRuntime.InvokeVoidAsync("setLocalStorage", "LocalValue", _insurance);
		}
		#endregion

		#region Privates
		private async Task LoadStateAsync()
		{
			_insurance = await GetAsync("getLocalStorage", "LocalValue");
		}

		private async Task<Insurance> GetAsync(string Name, string Key)
		{
			string json = await this.IjsRuntime.InvokeAsync<string>(Name, Key);

			return JsonSerializer.Deserialize<Insurance>(json);
		}
		#endregion
	}
}