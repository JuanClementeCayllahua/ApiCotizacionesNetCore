using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Lucky.EyGH.Domain.result;

namespace Lucky.EyGH.Repository.SqlServer
{
    public class ClienteDAO
    {
        private string cadenaconexion = "Data Source=LIM-6L892J3\\SQLEXPRESS;Initial " +
           "Catalog=BDLuckyCotizaciones;Integrated Security=SSPI;";

        public List<ClienteResult> obtenerClientes(int nIdCliente)
        {
            try
            {
                List<ClienteResult> clientes = new List<ClienteResult>();
                ClienteResult clientesEncontrados = null;
                string sentencia = "SELECT * FROM tbl_cliente where @nIdCliente = @nIdCliente";
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                    {

                        comando.Parameters.Add(new SqlParameter("@nIdCliente", nIdCliente));
                        using (SqlDataReader resultado = comando.ExecuteReader())
                        {
                            while (resultado.Read())
                            {
                                clientesEncontrados = new ClienteResult
                                {
                                    nIdCliente = (int)resultado["nIdCliente"],
                                    sRuc = (string)resultado["sRuc"],
                                    sRazonSocial = (string)resultado["sRazonSocial"],
                                    nEstado = (int)resultado["nEstado"]
                                };

                                clientes.Add(clientesEncontrados);
                            }
                        }
                    }


                }
                return clientes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
