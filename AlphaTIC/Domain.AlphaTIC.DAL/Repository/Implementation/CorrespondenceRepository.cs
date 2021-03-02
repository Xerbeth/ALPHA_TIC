#region Referencias
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
                    cmd.Parameters.Clear();
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

    }
}
