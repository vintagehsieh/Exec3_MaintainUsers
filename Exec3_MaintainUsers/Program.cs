using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exec3_MaintainUsers
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Insert("Kiwi", "KiwiAccount", "KiwiPwd");

			Update(1, "KiwiPassowrd");

			Delete(1);

			Select(0);

		}


		static void Insert(string name, string account, string password)
		{
			string sql = @"INSERT INTO Users(Name, Account, Password)
						   VALUES(@Name, @Account, @Password)";

			var dbHelper = new SqlDbHelper("default");
			var parameters = new SqlParametersBuilder().AddNVarchar("@Name", 50, name)
													   .AddNVarchar("@Account", 50, account)
													   .AddNVarchar("@Password", 50, password)
													   .Build();

			dbHelper.ExecuteNonQuery(sql, parameters);
			Console.WriteLine("紀錄已新增");

		}

		static void Update(int id, string password)
		{
			string sql = @"UPDATE Users 
						   SET password=@password
						   WHERE Id=@Id";
		
			var dbHelper = new SqlDbHelper("default");
			var parameters = new SqlParametersBuilder().AddInt("@Id", id)
													   .AddNVarchar("@Password", 50, password)
													   .Build();

			dbHelper.ExecuteNonQuery(sql, parameters);

			Console.WriteLine("紀錄已更新");
		}

		static void Delete(int id)
		{
			string sql = @"DELETE FROM Users WHERE Id=@Id";

			var dbHelper = new SqlDbHelper("default");
			var parameters = new SqlParametersBuilder().AddInt("@Id", id)
													   .Build();

			dbHelper.ExecuteNonQuery(sql, parameters);
			Console.WriteLine("紀錄已刪除");
		}

		static void Select(int id)
		{
			string sql = @"SELECT Name, Account, Password
				           FROM Users
						   WHERE Id = @Id";

			var dbHelper = new SqlDbHelper("default");
			var parameters = new SqlParametersBuilder().AddInt("Id", id).Build();

			DataTable dataSet = dbHelper.Select(sql, parameters);

			foreach(DataRow row in dataSet.Rows)
			{
				string name = row.Field<string>("Name");
				string account = row.Field<string>("Account");
				string password = row.Field<string>("Password");

			}
		}
	}

}
