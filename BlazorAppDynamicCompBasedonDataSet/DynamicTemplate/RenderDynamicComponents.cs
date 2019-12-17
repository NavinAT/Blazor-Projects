using System.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAppDynamicCompBasedonDataSet
{
	public class RenderDynamicComponents
	{
		#region Properties
		private static RenderFragment DynamicFragment { get; set; }
		#endregion

		#region Publics
		public static RenderFragment RenderControls(DataTable tabAnonymousTable)
		{
			if(DynamicFragment != null) return DynamicFragment;
			foreach(DataColumn dataColumn in tabAnonymousTable.Columns)
			{
				if(dataColumn.DataType == typeof(string))
				{
					DynamicFragment += renderBuilder =>
					                   {
						                   renderBuilder.OpenElement(0, "div");
						                   renderBuilder.AddAttribute(1, "class", "form-group");
						                   renderBuilder.OpenElement(2, "label");
						                   renderBuilder.AddAttribute(3, "for", dataColumn.ColumnName);
						                   renderBuilder.AddAttribute(4, "class", "custom-control-label");
						                   renderBuilder.AddContent(5, dataColumn.ColumnName);
						                   renderBuilder.CloseElement();
						                   renderBuilder.OpenElement(6, "input");
						                   renderBuilder.AddAttribute(7, "id", dataColumn.ColumnName);
						                   renderBuilder.AddAttribute(8, "class", "form-control");
						                   renderBuilder.CloseElement();
						                   renderBuilder.CloseElement();
					                   };
				}

				if(dataColumn.DataType == typeof(bool))
				{
					DynamicFragment += renderBuilder =>
					                   {
						                   renderBuilder.OpenElement(0, "div");
						                   renderBuilder.AddAttribute(1, "class", "checkbox");
						                   renderBuilder.OpenElement(2, "label");
						                   renderBuilder.AddContent(3, "Is Plan Selected");
						                   renderBuilder.CloseElement();
						                   renderBuilder.OpenElement(4, "br");
						                   renderBuilder.CloseElement();
						                   renderBuilder.OpenElement(5, "input");
						                   renderBuilder.AddAttribute(6, "type", "checkbox");
						                   renderBuilder.AddAttribute(7, "value", "");
						                   renderBuilder.CloseElement();
						                   renderBuilder.CloseElement();
					                   };
				}
			}

			return DynamicFragment;
		}

		public static RenderFragment RenderTextBox(DataTable tabAnonymousTable,string strFiieldName, string strStyleClass, string strLabelText, string strID)
		{
			RenderFragment DynamicTextBox = null;

			if(tabAnonymousTable.Columns[0].DataType == typeof(string))
			{
				DynamicTextBox = renderTextBox =>
				                 {
					                 renderTextBox.OpenElement(0, "div");
					                 renderTextBox.AddAttribute(1, "class", "form-group");
					                 renderTextBox.OpenElement(2, "label");
					                 renderTextBox.AddAttribute(3, "for", strID);
					                 renderTextBox.AddAttribute(4, "class", "custom-control-label");
					                 renderTextBox.AddContent(5, strLabelText);
					                 renderTextBox.CloseElement();
					                 renderTextBox.OpenComponent<InputText>(6);
					                 renderTextBox.AddAttribute(8, "ID", strID);
					                 renderTextBox.AddAttribute(7, "class", strStyleClass);
					                 renderTextBox.AddAttribute(8, "value", tabAnonymousTable.Rows[0][0]);
					                 renderTextBox.CloseComponent();
					                 renderTextBox.CloseElement();
				                 };
			}

			return DynamicTextBox;
		}
		#endregion
	}
}