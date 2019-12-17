using System;

namespace BlazorAppDynamicCompBasedonDataSet
{
	public class EDPlan
	{
		#region Properties
		public Guid PlanId { get; set; }
		public string PlanName { get; set; }
		public bool IsPlanSelected { get; set; }
		#endregion
	}
}