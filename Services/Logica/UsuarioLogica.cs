using ADOAPI.Models;
using ADOAPI.Services.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOAPI.Services.Logica
{
    public class UsuarioLogica : IUsuarios
    {

        //--------------------------------------------------------Metodo anterior-----------------------------------------------
        //readonly string CadenaSQL;
        //public Usuarios(IConfiguration config)
        //{
        //    CadenaSQL = config.GetConnectionString("CadenaSQL");
        //}
        //--------------------------------------------------------Metodo anterior-----------------------------------------------

        readonly Conexion cn = new(); //Instancia para llamar al Getter de la cadena de conexion



        public async Task<string> PostCrearUsuario(Usuario Ob)
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

                string response = "El usaurio se ha creado con exito";
                return await Task.FromResult(response);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            List<Usuario> lista = new();

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

            return await Task.FromResult(lista);
        }

        public async Task<string> PutEditarUsuario(Usuario Ob)
        {

            try
            {
                using (SqlConnection conexion = new(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", Ob.Id);
                    cmd.Parameters.AddWithValue("Nombre", Ob.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", Ob.Apellido);
                    cmd.Parameters.AddWithValue("Email", Ob.Email);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                var response = "Se ha editado el usuario";

                return await Task.FromResult(response);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public async Task<string> DeleteUsuario(string mail)
        {
            using (SqlConnection conexion = new(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar", conexion);
                cmd.Parameters.AddWithValue("Email", mail);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }

            var response = "Se ha eliminado el usuario";

            return await Task.FromResult(response);
        }

    }
}
