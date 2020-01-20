using System;
using System.Data;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorFormValidation.Pages
{
	public class FormField<TValue> : InputBase<TValue>
	{
		[Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must accept DataRow";
		#region Protecteds
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "input");
			builder.AddMultipleAttributes(1, AdditionalAttributes);
			builder.AddAttribute(2, "type", "text");
			builder.AddAttribute(3, "class", CssClass);
			builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValueAsString));
			builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
			builder.CloseElement();
		}

		protected override string FormatValueAsString(TValue value)
		{
			DataRow targetType = value as DataRow;

			return FormatValue(targetType, CultureInfo.CurrentCulture);
		}

		private static string FormatValue(DataRow row, CultureInfo culture)
		{
			return row.ToString();
		}

		protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
		{
			Type? targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

			bool success;
			if(targetType == typeof(DataRow))
			{
				success = TryParseDataRow(value, out result);
			}
			else
			{
				throw new InvalidOperationException($"The type '{targetType}' is not a supported date type.");
			}

			if(success)
			{
				validationErrorMessage = null;
				return true;
			}
			else
			{
				validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
				return false;
			}
		}
		#endregion

		#region Privates
		private static bool TryParseDataRow(string value, out TValue result)
		{
			bool success = TryConvertToDataRow(value, out DataRow parsedValue);
			if(success)
			{
				result = (TValue) (object) parsedValue;
				return true;
			}

			result = default;
			return false;
		}

		private static bool TryConvertToDataRow(object obj, out DataRow value)
		{
			return ConvertToDataRow(obj, out value);
		}

		private static bool ConvertToDataRow(object obj, out DataRow value)
		{
			value = (DataRow) obj;

			return true;
		}
		#endregion
	}
}