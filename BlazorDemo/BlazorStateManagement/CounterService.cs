using System;

namespace BlazorStateManagement
{
	public class CounterService
	{
		#region Events
		public event EventHandler StateChanged;
		#endregion

		#region Properties
		public int Count { get; private set; }
		#endregion

		#region Publics
		public int GetCurrentCount()
		{
			return this.Count;
		}

		public void Reset()
		{
			this.Count = 0;
			StateHasChanged();
		}

		public void SetCurrentCount(int nParamCount)
		{
			this.Count = nParamCount;
			StateHasChanged();
		}
		#endregion

		#region Privates
		private void StateHasChanged()
		{
			this.StateChanged?.Invoke(this, EventArgs.Empty);
		}
		#endregion
	}
}