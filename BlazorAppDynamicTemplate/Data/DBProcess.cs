using System.Data;
using System.Data.SqlClient;

namespace BlazorAppDynamicTemplate.Data
{
	public class DBProcess
	{
		#region Constants
		private static SqlConnection conSql; 
		#endregion

		#region Publics
		public static DataTable FetchAllEmployeeDetails()
		{
			DataTable tabEmployee = new DataTable();
			using(conSql = new SqlConnection("Data Source=MS-00603;Initial Catalog=EmployeeInformation;Persist Security Info=True;User ID=sa;Password=password-123"))
			{
				conSql.Open();
				const string strSelectQuery = "Select * from Employee";
				SqlDataAdapter daSql = new SqlDataAdapter(strSelectQuery, conSql);
				conSql.Close();

				daSql.Fill(tabEmployee);
			}

			return tabEmployee;
		}
		#endregion
	}
}