#region Referencias
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.Common.Models
{
    /// <summary>
    /// Clase modelo de la entidad Correspodence
    /// </summary>
    public class CorrespondenceModel : AuditModel
    {
        #region Propiedades
        /// <summary>
        /// Identificador del registro
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Descripción u observaciones de la correspondencia
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Consecutivo 
        /// </summary>
        public string Consecutive { get; set; }
        /// <summary>
        /// Tipo de correspondencia
        /// </summary>
        public string TypeCorrespondence { get; set; }
        /// <summary>
        /// Identificador de la persona remitente 
        /// </summary>
        public int SenderId { get; set; }
        /// <summary>
        /// Identificador de la persona destinataria
        /// </summary>
        public int AddresseeId { get; set; }
        #endregion Propiedades

        #region Métodos
        /// <summary>
        /// Método constructor
        /// </summary>
        public CorrespondenceModel() { }
        #endregion Métodos
    }
}
