using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio
{
    public class RepositorioDeportista : IRepositorioDeportista
    {
        public void IngresarDeportista(Entidades.Deportista deportista)
        {
            using (SqlConnection conexion = 
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["LigaNatacion"].ConnectionString))
            {
                conexion.Open();
                SqlTransaction tran = conexion.BeginTransaction();
                try
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexion;
                    comando.Transaction = tran;
                    comando.CommandText = "IngresarDeportista";
                    comando.Parameters.Add("@PrimerNombre", SqlDbType.VarChar).Value = deportista.PrimerNombre;
                    comando.Parameters.Add("@SegundoNombre", SqlDbType.VarChar).Value = deportista.SegundoNombre;
                    comando.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = deportista.PrimerApellido;
                    comando.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = deportista.SegundoApellido;
                    comando.Parameters.Add("@Documento", SqlDbType.BigInt).Value = deportista.NumeroDocumento;
                    comando.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = deportista.FechaNacimiento;
                    comando.Parameters.Add("@IdSexo", SqlDbType.SmallInt).Value = deportista.Sexo.Id;
                    comando.Parameters.Add("@IdTipoDocumento", SqlDbType.SmallInt).Value = deportista.TipoDocumento.Id;

                    comando.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public List<Entidades.Deportista> ObtenerDeportistas(string numeroDocumento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
        {
            List<Entidades.Deportista> deportistas = new List<Entidades.Deportista>();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["LigaNatacion"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarDeportistas";
                comando.Parameters.Add("@PrimerNombre", SqlDbType.VarChar).Value = primerNombre;
                comando.Parameters.Add("@SegundoNombre", SqlDbType.VarChar).Value = segundoNombre;
                comando.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = primerApellido;
                comando.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = segundoApellido;
                comando.Parameters.Add("@Documento", SqlDbType.BigInt).Value = numeroDocumento;
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.Deportista deportista = new Entidades.Deportista();
                        deportista.Id = Convert.ToInt64(reader["IdDeportista"]);
                        deportista.PrimerNombre = reader["PrimerNombre"].ToString();
                        deportista.SegundoNombre = reader["SegundoNombre"].ToString();
                        deportista.PrimerApellido = reader["PrimerApellido"].ToString();
                        deportista.SegundoApellido = reader["SegundoApellido"].ToString();
                        deportista.NumeroDocumento = reader["Documento"].ToString();
                        deportista.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        deportista.TipoDocumento = new Entidades.TipoDocumento()
                        {
                            Id = Convert.ToInt32(reader["IdTipoDocumento"]),
                            Nombre = reader["NombreTipoDocumento"].ToString()
                        };

                        deportistas.Add(deportista);
                    }
                }
            }
            return deportistas;
        }

        public DataTable ObtenerDeportistas()
        {
            DataTable deportistas = new DataTable();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["LigaNatacion"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarDeportistas";

                comando.Parameters.Add("@PrimerNombre", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@SegundoNombre", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@Documento", SqlDbType.BigInt).Value = string.Empty;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(deportistas);
            }

            return deportistas;
        }
    }
}
