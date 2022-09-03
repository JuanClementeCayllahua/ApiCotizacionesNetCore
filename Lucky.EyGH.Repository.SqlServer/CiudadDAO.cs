using Lucky.EyGH.Domain.result;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lucky.EyGH.Repository.SqlServer
{
    public class CiudadDAO
    {
        private string cadenaconexion = "Data Source=LIM-6L892J3\\SQLEXPRESS;Initial " +
           "Catalog=BDLuckyCotizaciones;Integrated Security=SSPI;";

        public List<CiudadResult> obtenerciudades(int nIdCiudad)
        {
            try
            {
                List<CiudadResult> ciudades = new List<CiudadResult>();
                CiudadResult ciudadesEncontradas = null;
                string sentencia = "SELECT * FROM tbl_ciudades where @nIdCiudad = @nIdCiudad";
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                    {

                        comando.Parameters.Add(new SqlParameter("@nIdCiudad", nIdCiudad));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            while (resultado.Read())
                            {
                                ciudadesEncontradas = new CiudadResult
                                {
                                    nIdCiudad = (int)resultado["nIdCiudad"],
                                    sCiudad = (string)resultado["sCiudad"],
                                    nEstado = (int)resultado["nEstado "],


                                };

                                ciudades.Add(ciudadesEncontradas);
                            }
                        }
                    }


                }
                return ciudades;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
