#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Common.Models;
using Domain.AlphaTIC.DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
#endregion Referencias

namespace Domain.AlphaTIC.DAL.Repository.Implementation
{
    /// <summary>
    /// Clase para la implementación de los métodos de operación expuestos para el acceso a la Base de datos de la entidad Person
    /// </summary>
    public class CorrespondenceRepository : ICorrespondenceRepository
    {
        #region Propiedades
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        #endregion Propiedades
        /// <summary>
        /// Método constructor con la cadena de conexión
        /// </summary>
        /// <param name="configuration"> Cadena de conexión </param>
        public CorrespondenceRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Método para registrar las peronas como remitentes, destinatarios o usuarios del sistema
        /// </summary>
        /// <param name="person"> Entidad persona </param>
        /// <returns> Bandera de creación del usuario </returns>
        public bool InsCorrespondence(CorrespondenceModel correspondence)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    cmd.Transaction = transaction;
                    cmd.CommandText = "develop.Ins_Correspondence";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 100));
                    cmd.Parameters["@Descripcion"].Value = correspondence.Description;
                    cmd.Parameters.Add(new SqlParameter("@Type_Correspondence", SqlDbType.VarChar, 50));
                    cmd.Parameters["@Type_Correspondence"].Value = correspondence.TypeCorrespondence;
                    cmd.Parameters.Add(new SqlParameter("@Sender_Id", SqlDbType.Int));
                    cmd.Parameters["@Sender_Id"].Value = correspondence.SenderId;
                    cmd.Parameters.Add(new SqlParameter("@Addressee_Id", SqlDbType.Int));
                    cmd.Parameters["@Addressee_Id"].Value = correspondence.AddresseeId;
                    cmd.Parameters.Add(new SqlParameter("@Creator_Person", SqlDbType.Int));
                    cmd.Parameters["@Creator_Person"].Value = correspondence.CreatorPerson;
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.BigInt));
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();                                        
                    int correspondence_Id = (int)(long)cmd.Parameters["@Id"].Value;
                    cmd.Parameters.Clear();

                    cmd.CommandText = "develop.Ins_Correspondence_Files";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100));
                    cmd.Parameters["@Name"].Value = correspondence.CorrespondenceFiles.Name;
                    cmd.Parameters.Add(new SqlParameter("@File_Type", SqlDbType.VarChar, 20));
                    cmd.Parameters["@File_Type"].Value = correspondence.CorrespondenceFiles.FileType;
                    cmd.Parameters.Add(new SqlParameter("@File_Path", SqlDbType.VarChar, 250));
                    cmd.Parameters["@File_Path"].Value = correspondence.CorrespondenceFiles.FilePath;
                    cmd.Parameters.Add(new SqlParameter("@Correspondence_Id", SqlDbType.Int));
                    cmd.Parameters["@Correspondence_Id"].Value = correspondence_Id;
                    cmd.Parameters.Add(new SqlParameter("@Creator_Person", SqlDbType.Int));
                    cmd.Parameters["@Creator_Person"].Value = correspondence.CreatorPerson;
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.BigInt));
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (ArgumentException ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            
        }

        /// <summary>
        /// Método para consultar la vista ViewCorrespondence
        /// </summary>
        /// <returns> Lista de resultados de consultar vista </returns>
        public List<CorrespondenceViewDto> GetViewCorrespondence()
        {
            List<CorrespondenceViewDto> correspondenceView = new List<CorrespondenceViewDto>();
            string queryString = "SELECT * FROM develop.view_correspondence;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CorrespondenceViewDto correspondence = new CorrespondenceViewDto();
                        correspondence.Description = reader[0].ToString();
                        correspondence.Consecutive = reader[1].ToString();
                        correspondence.Type_Correspondence = reader[2].ToString();
                        correspondence.Sender = reader[3].ToString();
                        correspondence.Addressee = reader[4].ToString();
                        correspondence.ReceptionDate = (DateTime)reader[5];
                        correspondence.FileName = reader[6].ToString();
                        correspondence.File = reader[7].ToString();
                        correspondenceView.Add(correspondence);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 04: Ocurrió un error consultando la vista de la base de datos.");
                }
                return correspondenceView;
            }
        }

    }
}
