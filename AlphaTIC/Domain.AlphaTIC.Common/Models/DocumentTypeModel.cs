#region Referencias
using System;
#endregion Referencias

namespace Domain.AlphaTIC.Common.Models
{
    /// <summary>
    /// Clase modelo de la entidad DocumentType de la base de datos
    /// </summary>
    public class DocumentTypeModel
    {
        #region Propiedades
        /// <summary>
        /// Identificador del registro
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del tipo de documento
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Código unico de registro para el tipo de documento
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción del tipo de documento
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Persona creadora del registro
        /// </summary>
        public int CreatorPerson { get; set; }
        /// <summary>
        /// Fecha última modificación del registro
        /// </summary>
        public DateTime? ModifierDate { get; set; }
        /// <summary>
        /// Persona última modificación del registro
        /// </summary>
        public int? ModifiesPerson { get; set; }
        /// <summary>
        /// Estado del registro; Activo o Inactivo
        /// </summary>
        public string RegistrationStatus { get; set; }
        #endregion Propiedades

        #region Métodos 
        /// <summary>
        /// Método constructor
        /// </summary>
        public DocumentTypeModel() { }
        #endregion Métodos
    }
}