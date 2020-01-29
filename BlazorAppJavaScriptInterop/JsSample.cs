using Microsoft.JSInterop;

namespace BlazorAppJavaScriptInterop
{
	public class JsSample
	{
		#region Fields
		private int COUNT;
		#endregion

		#region Publics
		[JSInvokable]
		public int IncrementCount()
		{
			return COUNT++;
		}
		#endregion
	}
}