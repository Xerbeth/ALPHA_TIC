#region Referencias
using System;
#endregion Referencias

namespace Domain.AlphaTIC.Common.Models
{
    /// <summary>
    /// Clase modelo de la entidad DocumentType de la base de datos
    /// </summary>
    public class PersonModel : AuditModel
    {
        #region Propiedades
        /// <summary>
        /// Identificador del registro
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Primer nombre
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Segundo nombre
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Primer apellido
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Segundo apellido
        /// </summary>
        public string SecondSurname { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Tipo de documento de identificación
        /// </summary>
        public int DocumentTypeId { get; set; }
        /// <summary>
        /// Número de documento de identificación
        /// </summary>
        public string DocumentNumber { get; set; }
        /// <summary>
        /// Número de telefono de contacto
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Correo electronico de contacto
        /// </summary>
        public string Email { get; set; }
        #endregion Propiedades

        #region Métodos 
        /// <summary>
        /// Método constructor
        /// </summary>
        public PersonModel() { }
        #endregion Métodos
    }
}