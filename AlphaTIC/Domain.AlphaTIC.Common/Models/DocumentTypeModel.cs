#region Referencias
using System;
#endregion Referencias

namespace Domain.AlphaTIC.Common.Models
{
    /// <summary>
    /// Clase modelo de la entidad DocumentType de la base de datos
    /// </summary>
    public class DocumentTypeModel : AuditModel
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
        #endregion Propiedades

        #region Métodos 
        /// <summary>
        /// Método constructor
        /// </summary>
        public DocumentTypeModel() { }
        #endregion Métodos
    }
}