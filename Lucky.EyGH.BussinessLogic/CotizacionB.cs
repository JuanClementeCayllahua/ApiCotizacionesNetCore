using Lucky.EyGH.Domain.result;
using Lucky.EyGH.Repository.SqlServer;
using System;
using System.Collections.Generic;

namespace Lucky.EyGH.BussinessLogic
{
    public class CotizacionB
    {
        ArticuloDAO articuloDAO = new ArticuloDAO();
        CiudadDAO ciudadDAO = new CiudadDAO();
        ClienteDAO clienteDAO = new ClienteDAO();

        public List<ArticuloResult> listarArticulos()
        {
            List<ArticuloResult> articulosBD = articuloDAO.obtenerArticulos(1);


            return articulosBD;
        }

        public List<CiudadResult> listarCiudades()
        {
            List<CiudadResult> ciudadBD = ciudadDAO.obtenerciudades(1);
            return ciudadBD;
        }
        public List<ClienteResult> listarClientes()
        {
            List<ClienteResult> clientesBD = clienteDAO.obtenerClientes(1);
            return clientesBD;
        }

    }
}
