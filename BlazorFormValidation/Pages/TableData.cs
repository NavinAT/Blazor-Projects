using System.Data;
using System.Data.SqlClient;

namespace BlazorInsuranceApp
{
	public class TableData
	{
		#region Fields
		private static SqlConnection connection;
		private static DataTable tabAnonymous;
		private static SqlDataAdapter dataAdapter;
		//private static SqlDataReader dataReader;
		#endregion

		#region Publics
		public static DataTable GetInsurance(string strTableName)
		{
			using(connection = new SqlConnection("Data Source=MS-00603;Initial Catalog=BlazorEducation;Persist Security Info=True;User ID=sa;Password=password-123"))
			{
				string sqlQuery = $"select * from {strTableName} where InsSubNr = 10006 ";
				connection.Open();

				dataAdapter = new SqlDataAdapter(sqlQuery, connection);
				tabAnonymous = new DataTable();

				dataAdapter.Fill(tabAnonymous);
			}

			return tabAnonymous;
		}
		#endregion
	}
}