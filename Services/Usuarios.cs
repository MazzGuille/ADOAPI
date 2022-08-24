using ADOAPI.Models;
using ADOAPI.Services.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOAPI.Services
{
    public class Usuarios : IUsuarios
    {


        //readonly string CadenaSQL;

        //public Usuarios(IConfiguration config)
        //{
        //    CadenaSQL = config.GetConnectionString("CadenaSQL");
        //}


        readonly Conexion cn = new(); //Instancia para llamar al Getter de la cadena de conexion


        public void PostCrearUsuario(Usuario Ob)
        {
            try
            {
                using (SqlConnection conexion = new(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", Ob.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", Ob.Apellido);
                    cmd.Parameters.AddWithValue("Email", Ob.Email);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }


        }

        public List<Usuario> GetAllUsuarios()
        {
            List<Usuario> lista = new();

            try
            {
                using (SqlConnection conexion = new(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new("SP_Listar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())//El "SqlDataReader" se puede reemplazar por un "var"
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Email = reader["Email"].ToString()
                            });

                        }
                    }
                }
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }
        }

        //public void GetUsuario(Usuario Ob)
        //{

        //    try
        //    {
        //        using (SqlConnection conexion = new(CadenaSQL))
        //        {
        //            conexion.Open();
        //            SqlCommand cmd = new("SP_Obtener", conexion);
        //            cmd.Parameters.AddWithValue("Email", Ob.Email);
        //            cmd.CommandType = CommandType.StoredProcedure;


        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message.ToString());
        //    }
        //}

        public void PutEditarUsuario(Usuario Ob)
        {
            try
            {
                using (SqlConnection conexion = new(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", Ob.Id == 0 ? DBNull.Value : Ob.Id);
                    cmd.Parameters.AddWithValue("Nombre", Ob.Nombre is null ? DBNull.Value : Ob.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", Ob.Apellido is null ? DBNull.Value : Ob.Apellido);
                    cmd.Parameters.AddWithValue("Email", Ob.Email is null ? DBNull.Value : Ob.Email);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }
        }

        public void DeleteUsuario(string mail)
        {
            try
            {
                using (SqlConnection conexion = new(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Email", mail);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }
        }








    }
}
