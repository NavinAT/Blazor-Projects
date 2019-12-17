using System.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorAppDynamicTemplate.DynamicTemplate
{
	public class DynamicTableTemplate
	{
		#region Publics
		public static RenderFragment BuildTable(DataTable tabEmployee)
		{
			void RenderFragment(RenderTreeBuilder builder)
			{
				builder.OpenElement(0, "table");
				builder.AddAttribute(1, "class", "table");
				builder.OpenElement(2, "tbody");
				builder.OpenElement(3, "tr");
				foreach(DataColumn col in tabEmployee.Columns)
				{
					builder.OpenElement(4, "th");
					builder.AddContent(5, col.ColumnName);
					builder.CloseElement();
				}

				builder.CloseElement();

				foreach(DataRow row in tabEmployee.Rows)
				{
					builder.OpenElement(6, "tr");
					foreach(DataColumn col in tabEmployee.Columns)
					{
						builder.OpenElement(7, "td");
						builder.AddContent(8, row[col.ColumnName]);
						builder.CloseElement();
					}

					builder.CloseElement();
				}

				builder.CloseElement();
				builder.CloseElement();
			}

			return RenderFragment;
		}
		#endregion
	}
}