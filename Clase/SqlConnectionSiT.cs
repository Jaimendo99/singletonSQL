using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Clase
{
	public class SqlConnectionST
	{
		private readonly SqlConnection conn;

		private SqlConnection()
		{
		}
		

		public static SqlConnectionST getInstance()
		{
			if (conn == null)
			{
				conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
			}
			return conn;
		}

	}
}