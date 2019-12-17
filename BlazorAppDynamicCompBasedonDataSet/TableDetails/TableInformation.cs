using System.Data;
using System.Data.SqlClient;

namespace BlazorAppDynamicCompBasedonDataSet
{
	public class TableInformation
	{
		#region Fields
		private static SqlConnection sqlConnection;
		private static DataSet dcTable;
		private static SqlDataAdapter dataAdapter;
		#endregion

		#region Publics
		public static DataTable GetTableColumn(string strTableName)
		{
			using(sqlConnection = new SqlConnection("Data Source=MS-00603;Initial Catalog=BlazorEducation;Persist Security Info=True;User ID=sa;Password=password-123"))
			{
				sqlConnection.Open();
				string strQuery = "select * from " + strTableName + "";
				dataAdapter = new SqlDataAdapter(strQuery, sqlConnection);
				sqlConnection.Close();

				dcTable = new DataSet();
				dataAdapter.Fill(dcTable);
			}

			return dcTable.Tables[0];
		}

		public static DataTable GetTableWithSpecifiedColumn(string strTableName, string strFieldName)
		{
			using(sqlConnection = new SqlConnection("Data Source=MS-00603;Initial Catalog=BlazorEducation;Persist Security Info=True;User ID=sa;Password=password-123"))
			{
				sqlConnection.Open();
				string strQuery = $"select {strFieldName} from {strTableName}";
				dataAdapter = new SqlDataAdapter(strQuery, sqlConnection);
				sqlConnection.Close();

				dcTable = new DataSet();
				dataAdapter.Fill(dcTable);
			}

			return dcTable.Tables[0];
		}
		#endregion
	}
}