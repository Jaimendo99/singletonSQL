using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Clase
{
	public class SqlConnectionST
	{
		private readonly SqlConnection conn;

		private SqlConnectionST()
		{
		}
		
		public static SqlConnection getInstance()
		{
			if (conn == null)
			{
				conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
			}
			return conn;
		}

	}
}