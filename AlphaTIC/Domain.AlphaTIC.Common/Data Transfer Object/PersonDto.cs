#region Referencias
using System;
#endregion Referencias

namespace Domain.AlphaTIC.Common.Data_Transfer_Object
{
    /// <summary>
    /// Clase para mostrar la información relevante de la tabla Person
    /// </summary>
    public class PersonDto : AuditDto
    {
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
        public PersonDto() { }
    }
}
