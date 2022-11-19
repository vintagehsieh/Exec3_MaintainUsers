using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	public class SqlParametersBuilder
	{
		private List<SqlParameter> parameters = new List<SqlParameter>();

		public SqlParametersBuilder AddNVarchar(string name, int length, string value)
		{
			var param = new SqlParameter(name, SqlDbType.NVarChar, length) { Value = value };

			parameters.Add(param);

			return this;
		}

		public SqlParametersBuilder AddInt(string name, int value)
		{
			var param = new SqlParameter(name, SqlDbType.Int) { Value = value };

			parameters.Add(param);

			return this;
		}

		public SqlParametersBuilder AddDateTime(string name, DateTime value)
		{
			var param = new SqlParameter(name, SqlDbType.DateTime) { Value = value };

			parameters.Add(param);

			return this;
		}

		public SqlParameter[] Build()
		{
			return parameters.ToArray();
		}


	}
}
