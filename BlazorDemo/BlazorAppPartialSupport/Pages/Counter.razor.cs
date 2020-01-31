namespace BlazorAppPartialSupport.Pages
{
	public partial class Counter
	{
		#region Fields
		private int currentCount;
		#endregion

		#region Privates
		private void IncrementCount()
		{
			currentCount++;
		}
		#endregion
	}
}