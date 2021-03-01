#region Referencias
using Domain.AlphaTIC.Common.Models;
using Domain.AlphaTIC.DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
#endregion Referencias

namespace Domain.AlphaTIC.DAL.Repository.Implementation
{
    /// <summary>
    /// Clase para la impleentación de los métodos de operación expuestos para el acceso a la Base de datos de la entidad DocumentType
    /// </summary>
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        #region Propiedades
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        #endregion Propiedades
        /// <summary>
        /// Método constructor con la cadena de conexión
        /// </summary>
        /// <param name="configuration"> Cadena de conexión </param>
        public DocumentTypeRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Método para obtener los registros de la tabla DocumentType
        /// </summary>
        /// <returns> Lista de los registros de la entidad DocumentType </returns>
        List<DocumentTypeModel> IDocumentTypeRepository.GetListDocumentType()
        {
            List<DocumentTypeModel> listDocumentTypeModel = new List<DocumentTypeModel>();
            string queryString = "SELECT * FROM develop.Document_Type;";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DocumentTypeModel documentType = new DocumentTypeModel();
                        documentType.Id = (int)reader[0];
                        documentType.Name = reader[1].ToString();
                        documentType.Code = reader[2].ToString();
                        documentType.Description = (reader[3] == System.DBNull.Value) ? string.Empty : reader[3].ToString();
                        documentType.CreationDate = (DateTime)reader[4];
                        documentType.CreatorPerson = (int)reader[5];
                        documentType.ModifierDate = (reader[6] == System.DBNull.Value) ? default : (DateTime)reader[6];
                        documentType.ModifiesPerson = (reader[7] == System.DBNull.Value) ? default : (int)reader[7];
                        documentType.RegistrationStatus = reader[8].ToString();
                        listDocumentTypeModel.Add(documentType);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 01: Ocurrió un error consultando la base de datos.");
                }
                return listDocumentTypeModel;
            }
        }

    }
}
