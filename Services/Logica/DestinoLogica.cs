using ADOAPI.Models;
using ADOAPI.Services.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace ADOAPI.Services.Logica
{
    public class DestinoLogica : IDestinos
    {

        readonly Conexion cn = new(); //Instancia para llamar al Getter de la cadena de conexion


        public void PostCrearDestino(Destino Ob)
        {
            using (SqlConnection conexion = new(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_GuardarDest", conexion);
                cmd.Parameters.AddWithValue("Ciudad", Ob.Ciudad);
                cmd.Parameters.AddWithValue("Pais", Ob.Pais);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public List<Destino> GetAllDestino()
        {
            List<Destino> lista = new();

            using (SqlConnection conexion = new(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new("SP_ListarDest", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())//El "SqlDataReader" se puede reemplazar por un "var"
                {
                    while (reader.Read())
                    {
                        lista.Add(new Destino()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Ciudad = reader["Ciudad"].ToString(),
                            Pais = reader["Pais"].ToString()
                        });
                    }
                }
            }
            return lista;
        }


        public void PutEditarDestino(Destino Ob)
        {
            using (SqlConnection conexion = new(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_EditarDest", conexion);
                cmd.Parameters.AddWithValue("Id", Ob.Id);
                cmd.Parameters.AddWithValue("Ciudad", Ob.Ciudad);
                cmd.Parameters.AddWithValue("Pais", Ob.Pais);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteDestino(int id)
        {
            using (SqlConnection conexion = new(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_EliminarDest", conexion);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
