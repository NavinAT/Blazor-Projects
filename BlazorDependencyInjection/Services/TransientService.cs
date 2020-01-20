using System;

namespace BlazorDependencyInjection
{
	public class TransientService
	{
		#region Properties
		public Guid RandomGuid { get; } = Guid.NewGuid();
		#endregion
	}
}