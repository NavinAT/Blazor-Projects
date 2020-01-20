using System;

namespace BlazorDependencyInjection
{
	public class ScopedService
	{
		#region Properties
		public Guid RandomGuid { get; } = Guid.NewGuid();
		#endregion
	}
}