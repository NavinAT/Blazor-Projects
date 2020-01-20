using System;

namespace BlazorDependencyInjection
{
	public class SingletonService
	{
		#region Properties
		public Guid RandomGuid { get; } = Guid.NewGuid();
		#endregion
	}
}