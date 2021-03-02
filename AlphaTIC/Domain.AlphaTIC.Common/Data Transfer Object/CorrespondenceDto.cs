using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AlphaTIC.Common.Data_Transfer_Object
{
    /// <summary>
    /// Clase de transporte para Correspodence
    /// </summary>
    public class CorrespondenceDto : AuditDto
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
        /// <summary>
        /// Propiedad para los archivos subidos temporalmente
        /// </summary>
        public CorrespondenceFilesDto CorrespondenceFiles { get; set; }
        #endregion Propiedades

        #region Métodos
        /// <summary>
        /// Método constructor
        /// </summary>
        public CorrespondenceDto() { }
        #endregion Métodos
    }
}
