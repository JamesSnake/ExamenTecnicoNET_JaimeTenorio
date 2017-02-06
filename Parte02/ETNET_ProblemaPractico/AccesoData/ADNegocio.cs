using EntidadNegocio.Banco;
using EntidadNegocio.Banco.Request;
using EntidadNegocio.Banco.Response;
using EntidadNegocio.Estado;
using EntidadNegocio.Estado.Request;
using EntidadNegocio.Estado.Response;
using EntidadNegocio.Moneda;
using EntidadNegocio.Moneda.Request;
using EntidadNegocio.Moneda.Response;
using EntidadNegocio.OrdenPago;
using EntidadNegocio.OrdenPago.Request;
using EntidadNegocio.OrdenPago.Response;
using EntidadNegocio.Sucursal;
using EntidadNegocio.Sucursal.Request;
using EntidadNegocio.Sucursal.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoData
{
    public class ADNegocio
    {
        #region Consultas
        public BancoResponse ConsultarBanco(BancoRequest filtro) {
            BancoResponse Resultado = new BancoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ConsultarBanco", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoBanco", filtro.CodigoBanco ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre ?? (object)DBNull.Value);
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Resultado.ListaBanco.Add(new ENBanco {
                                    CodigoBanco = dr.GetInt32(dr.GetOrdinal("CodigoBanco")),
                                    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                    Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                    FechaRegistro = dr.GetDateTime(dr.GetOrdinal("FechaRegistro"))
                                }); 
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message; 
            }
                return Resultado; 
        }

       public SucursalResponse ConsultarSucursal(SucursalRequest filtro)
        {
            SucursalResponse Resultado = new SucursalResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ConsultarSucursal", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoSucursal", filtro.CodigoSucursal ?? (object)DBNull.Value);  
                        cmd.Parameters.AddWithValue("@CodigoBanco", filtro.CodigoBanco ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre ?? (object)DBNull.Value);
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Resultado.ListaSucursal.Add(new ENSucursal
                            {
                                CodigoSucursal = dr.GetInt32(dr.GetOrdinal("CodigoSucursal")),
                                CodigoBanco = dr.GetInt32(dr.GetOrdinal("CodigoBanco")),
                                Banco = dr.GetString(dr.GetOrdinal("Banco")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                FechaRegistro = dr.GetDateTime(dr.GetOrdinal("FechaRegistro"))
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

       public OrdenPagoResponse ConsultarOrdenPago(OrdenPagoRequest filtro)
        {
            OrdenPagoResponse Resultado = new OrdenPagoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ConsultarOrdenPago", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoOrdenPago", filtro.CodigoOrdenPago ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CodigoSucursal", filtro.CodigoSucursal ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CodigoMoneda", filtro.CodigoMoneda ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CodigoEstado", filtro.CodigoEstado ?? (object)DBNull.Value);

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Resultado.ListaOrdenPago.Add(new ENOrdenPago
                            {
                               CodigoOrdenPago = dr.GetInt32(dr.GetOrdinal("CodigoOrdenPago")),
                               CodigoSucursal = dr.GetInt32(dr.GetOrdinal("CodigoSucursal")),
                               Sucursal = dr.GetString(dr.GetOrdinal("Sucursal")),
                               Monto = dr.GetDecimal(dr.GetOrdinal("Monto")),
                               CodigoMoneda = dr.GetInt32(dr.GetOrdinal("CodigoMoneda")),
                               Moneda = dr.GetString(dr.GetOrdinal("Moneda")),
                               CodigoEstado = dr.GetInt32(dr.GetOrdinal("CodigoEstado")),
                               Estado = dr.GetString(dr.GetOrdinal("Estado")),
                               FechaPago = dr.GetDateTime(dr.GetOrdinal("FechaPago"))
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public MonedaResponse ConsultarMoneda(MonedaRequest filtro)
        {
            MonedaResponse Resultado = new MonedaResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ConsultarMoneda", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoMoneda", filtro.CodigoMoneda ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre ?? (object)DBNull.Value);
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Resultado.ListaMoneda.Add(new ENMoneda
                            {
                                CodigoMoneda = dr.GetInt32(dr.GetOrdinal("CodigoMoneda")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                Abreviatura = dr.GetString(dr.GetOrdinal("Abreviatura"))
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public EstadoResponse ConsultarEstado(EstadoRequest filtro)
        {
            EstadoResponse Resultado = new EstadoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ConsultarEstado", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoEstado", filtro.CodigoEstado ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre ?? (object)DBNull.Value);
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Resultado.ListaEstado.Add(new ENEstado
                            {
                                CodigoEstado = dr.GetInt32(dr.GetOrdinal("CodigoEstado")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                Abreviatura = dr.GetString(dr.GetOrdinal("Abreviatura"))
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }
        #endregion

        #region Registro

        public BancoResponse RegistrarBanco(BancoRequest filtro)
        {
            BancoResponse Resultado = new BancoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_InsertarBanco", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", filtro.Direccion);
                        cmd.Parameters.AddWithValue("@FechaRegistro", filtro.FechaRegistro);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public SucursalResponse RegistrarSucursal(SucursalRequest filtro)
        {
            SucursalResponse Resultado = new SucursalResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_InsertarSucursal", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoBanco", filtro.CodigoBanco);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", filtro.Direccion);
                        cmd.Parameters.AddWithValue("@FechaRegistro", filtro.FechaRegistro);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public EstadoResponse RegistrarEstado(EstadoRequest filtro)
        {
            EstadoResponse Resultado = new EstadoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_InsertarEstado", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Abreviatura", filtro.Abreviatura);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public MonedaResponse RegistrarMoneda(MonedaRequest filtro)
        {
            MonedaResponse Resultado = new MonedaResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_InsertarMoneda", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Abreviatura", filtro.Abreviatura);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public OrdenPagoResponse RegistrarOrdenPago(OrdenPagoRequest filtro)
        {
            OrdenPagoResponse Resultado = new OrdenPagoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_InsertarOrdenPago", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoSucursal", filtro.CodigoSucursal);
                        cmd.Parameters.AddWithValue("@Monto", filtro.Monto);
                        cmd.Parameters.AddWithValue("@CodigoMoneda", filtro.CodigoMoneda);
                        cmd.Parameters.AddWithValue("@CodigoEstado", filtro.CodigoEstado);
                        cmd.Parameters.AddWithValue("@FechaPago", filtro.FechaPago);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        #endregion

        #region Actualizacion

        public BancoResponse ActualizarBanco(BancoRequest filtro)
        {
            BancoResponse Resultado = new BancoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarBanco", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoBanco", filtro.CodigoBanco);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Direccion", filtro.Direccion);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public SucursalResponse ActualizarSucursal(SucursalRequest filtro)
        {
            SucursalResponse Resultado = new SucursalResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarSucursal", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoSucursal", filtro.CodigoSucursal);
                        cmd.Parameters.AddWithValue("@CodigoBanco", filtro.CodigoBanco);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Direccion);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public EstadoResponse ActualizarEstado(EstadoRequest filtro)
        {
            EstadoResponse Resultado = new EstadoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarEstado", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoEstado", filtro.CodigoEstado);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Abreviatura", filtro.Abreviatura);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public MonedaResponse ActualizarMoneda(MonedaRequest filtro)
        {
            MonedaResponse Resultado = new MonedaResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarMoneda", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoMoneda", filtro.CodigoMoneda);
                        cmd.Parameters.AddWithValue("@Nombre", filtro.Nombre);
                        cmd.Parameters.AddWithValue("@Abreviatura", filtro.Abreviatura);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public OrdenPagoResponse ActualizarOrdenPago(OrdenPagoRequest filtro)
        {
            OrdenPagoResponse Resultado = new OrdenPagoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarOrdenPago", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoOrdenPago", filtro.CodigoOrdenPago);
                        cmd.Parameters.AddWithValue("@CodigoSucursal", filtro.CodigoSucursal);
                        cmd.Parameters.AddWithValue("@Monto", filtro.Monto);
                        cmd.Parameters.AddWithValue("@CodigoMoneda", filtro.CodigoMoneda);
                        cmd.Parameters.AddWithValue("@CodigoEstado", filtro.CodigoEstado);
                        cmd.Parameters.AddWithValue("@FechaPago", filtro.FechaPago);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        #endregion

        #region Eliminacion

        public BancoResponse EliminarBanco(BancoRequest filtro)
        {
            BancoResponse Resultado = new BancoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_EliminarBanco", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoBanco", filtro.CodigoBanco);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public SucursalResponse EliminarSucursal(SucursalRequest filtro)
        {
            SucursalResponse Resultado = new SucursalResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_EliminarSucursal", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoSucursal", filtro.CodigoSucursal);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public EstadoResponse EliminarEstado(EstadoRequest filtro)
        {
            EstadoResponse Resultado = new EstadoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_EliminarEstado", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoEstado", filtro.CodigoEstado);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public MonedaResponse EliminarMoneda(MonedaRequest filtro)
        {
            MonedaResponse Resultado = new MonedaResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_EliminarMoneda", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoMoneda", filtro.CodigoMoneda);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        public OrdenPagoResponse EliminarOrdenPago(OrdenPagoRequest filtro)
        {
            OrdenPagoResponse Resultado = new OrdenPagoResponse();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Configuracion.CadenaConexion("BDNegocio")))
                {

                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_EliminarOrdenPago", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoOrdenPago", filtro.CodigoOrdenPago);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Resultado.CodigoError = -1;
                Resultado.DescripcionError = e.Message;
            }
            return Resultado;
        }

        #endregion

    }
}
