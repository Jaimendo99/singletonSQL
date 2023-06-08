using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CRUD.Clase;
using CRUD.Utilities;

namespace CRUD.Pages
{
    public partial class Index : System.Web.UI.Page
    { 
        readonly SqlConnection con = SqlConnectionST.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
		{
			// Obtener la fecha actual
			DateTime fechaActual = DateTime.Now;

			// Ruta del archivo de log
			string rutaArchivoLog = Server.MapPath("~/Logs/log.txt");

			try
			{
				// Escribir la fecha y "CREATE" en el archivo de log
				string mensajeLog = $"CREATE {fechaActual}";
				File.AppendAllText(rutaArchivoLog, mensajeLog + Environment.NewLine);

				Response.Redirect("~/Pages/CRUD.aspx?op=C");
			}
			catch (Exception ex)
			{
			}
		}

		protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id="+id+"&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=D");
        }
    }
}