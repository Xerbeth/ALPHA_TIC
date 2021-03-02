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
    public class PersonRepository : IPersonRepository
    {
        #region Propiedades
        private IConfiguration Configuration;
        private readonly string ConnectionString;
        #endregion Propiedades
        /// <summary>
        /// Método constructor con la cadena de conexión
        /// </summary>
        /// <param name="configuration"> Cadena de conexión </param>
        public PersonRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Método para registrar las peronas como remitentes, destinatarios o usuarios del sistema
        /// </summary>
        /// <param name="person"> Entidad persona </param>
        /// <returns> Bandera de creación del usuario </returns>
        public bool InsPerson(PersonModel person)
        {
            bool flag = false;            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("develop.Ins_Person", connection))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@First_Name", SqlDbType.VarChar, 50));
                    cmd.Parameters["@First_Name"].Value = person.FirstName;
                    cmd.Parameters.Add(new SqlParameter("@Second_Name", SqlDbType.VarChar, 50));
                    cmd.Parameters["@Second_Name"].Value = person.SecondName;
                    cmd.Parameters.Add(new SqlParameter("@Surname", SqlDbType.VarChar, 50));
                    cmd.Parameters["@Surname"].Value = person.Surname;
                    cmd.Parameters.Add(new SqlParameter("@Second_Surname", SqlDbType.VarChar, 50));
                    cmd.Parameters["@Second_Surname"].Value = person.SecondSurname;
                    cmd.Parameters.Add(new SqlParameter("@Birth_Date", SqlDbType.DateTime));
                    cmd.Parameters["@Birth_Date"].Value = person.BirthDate;
                    cmd.Parameters.Add(new SqlParameter("@Document_Type_Id", SqlDbType.Int));
                    cmd.Parameters["@Document_Type_Id"].Value = person.DocumentTypeId;
                    cmd.Parameters.Add(new SqlParameter("@Document_Number", SqlDbType.VarChar, 20));
                    cmd.Parameters["@Document_Number"].Value = person.DocumentNumber;
                    cmd.Parameters.Add(new SqlParameter("@Phone_Number", SqlDbType.VarChar, 15));
                    cmd.Parameters["@Phone_Number"].Value = person.PhoneNumber;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                    cmd.Parameters["@Email"].Value = person.Email;
                    cmd.Parameters.Add(new SqlParameter("@Creator_Person", SqlDbType.Int));
                    cmd.Parameters["@Creator_Person"].Value = person.CreatorPerson;
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.BigInt));
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Output;                    

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    int id = (int)(long)cmd.Parameters["@Id"].Value;
                    flag = (id > 0) ? true : false;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error 02: Ocurrió registrando con el contexto de la base de datos.");
                }
                finally
                {
                    connection.Close();
                }                
            }

            return flag;
        }
    }
}
