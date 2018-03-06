using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Busqueda
{
    class ConsultaSQL
    {
        private SqlConnection conexion = new SqlConnection("Data Source = 10.10.50.201; Initial Catalog = ANCONA_PROD; user id=sa; password=Pr0c3s0.12");
        private DataSet ds;
        public DataTable MostrarDatos()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select ItemCode, Dscription, Quantity from DRF1 where DocEntry = '100'", conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable Buscar(string ticket)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select ItemCode, Dscription, Quantity from DRF1 where DocEntry = '100'", ticket), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
    }
}
