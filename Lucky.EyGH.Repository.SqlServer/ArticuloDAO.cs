using Lucky.EyGH.Domain.result;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lucky.EyGH.Repository.SqlServer
{
    public class ArticuloDAO
    {
        private string cadenaconexion = "Data Source=LIM-6L892J3\\SQLEXPRESS;Initial " +
            "Catalog=BDLuckyCotizaciones;Integrated Security=SSPI;";

        public List<ArticuloResult> obtenerArticulos(int nIdArticulo)
        {
            try
            {
                List<ArticuloResult> articulos = new List<ArticuloResult>();
                ArticuloResult productosencontrados = null;
                string sentencia = "SELECT * FROM tbl_articulos where @nIdArticulo = @nIdArticulo";
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                    {

                        comando.Parameters.Add(new SqlParameter("@nIdArticulo", nIdArticulo));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            while (resultado.Read())
                            {
                                productosencontrados = new ArticuloResult
                                {
                                    nIdArticulo = (int)resultado["nIdArticulo"],
                                    sNombreArticulo = (string)resultado["sNombreArticulo"]
                                };

                                articulos.Add(productosencontrados);
                            }
                        }
                    }


                }
                return articulos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
