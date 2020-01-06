using System.Collections.Generic;
using System.Globalization;
using BlazorInsuranceApp.InsuranceManagement;
using Microsoft.AspNetCore.Components;

namespace BlazorInsuranceApp
{
	public class RenderDynamicControl
	{
		#region Properties
		//public static List<RenderFragment> DynamicControls = new List<RenderFragment>();
		public static RenderFragment DynamicControls { get; set; }
		#endregion

		#region Publics
		public static RenderFragment RenderFormControls(string strControlType, string strLabelText, object Bind /*, string BindingField*/)
		{
			//RenderFragment controlFragment;

			switch(strControlType)
			{
				case "TBText":
					
					DynamicControls = builder =>
					                  {
						                  builder.AddMarkupContent(0, $"<label>{strLabelText}</label><br />");
						                  builder.OpenElement(1, "input");
						                  builder.AddAttribute(2, "type", "text");
						                  builder.AddAttribute(3, "value", Bind);
						                  //builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder(objField, _value => Bind. = _value, Bind, CultureInfo.InvariantCulture));
						                  builder.CloseElement();
					                  };

					//DynamicControls.Add(controlFragment);
					return DynamicControls;
					
				case "TBNumber":
					DynamicControls = builder =>
					                  {
						                  builder.AddMarkupContent(0, $"<label>{strLabelText}</label><br />");
						                  builder.OpenElement(1, "input");
						                  builder.AddAttribute(2, "type", "number");
						                  builder.AddAttribute(3, "value", Bind);
						                  builder.CloseElement();
					                  };

					//DynamicControls.Add(controlFragment);
					return DynamicControls;
			}

			return null;
		}
		#endregion
	}
}