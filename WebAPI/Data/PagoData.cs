using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Data;
using WebAPI.Models;

namespace WebApi.Data
{
    public class PagoData
    {
        public static bool Registrar(Pago oPago)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrarPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", oPago.Fecha);
                cmd.Parameters.AddWithValue("@monto", oPago.Monto);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Pago oPago)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificarPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpago", oPago.IdPago);
                cmd.Parameters.AddWithValue("@fecha", oPago.Fecha);
                cmd.Parameters.AddWithValue("@monto", oPago.Monto);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Pago> Listar()
        {
            List<Pago> oListaPago = new List<Pago>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarPagos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaPago.Add(new Pago()
                            {
                                IdPago = Convert.ToInt32(dr["IdPago"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                Monto = Convert.ToInt32(dr["Monto"])
                            });
                        }
                    }

                    return oListaPago;
                }
                catch (Exception ex)
                {
                    return oListaPago;
                }
            }
        }

        public static Pago Obtener(int idpago)
        {
            Pago oPago = new Pago();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpago", idpago);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oPago = new Pago()
                            {
                                IdPago = Convert.ToInt32(dr["IdPago"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]),
                                Monto = Convert.ToInt32(dr["Monto"])
                            };
                        }
                    }

                    return oPago;
                }
                catch (Exception ex)
                {
                    return oPago;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarPago", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpago", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
