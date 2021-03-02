using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AlphaTIC.Common.Data_Transfer_Object
{
    /// <summary>
    /// Clase para transportar la información de la vista
    /// </summary>
    public class CorrespondenceViewDto
    {
        /// <summary>
        /// Descripción de la documentación 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Consencutivo
        /// </summary>
        public string Consecutive { get; set; }
        /// <summary>
        /// Tipo de correspondencia
        /// </summary>
        public string Type_Correspondence { get; set; }
        /// <summary>
        /// Remitente
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public string Addressee { get; set; }
        /// <summary>
        /// Fecha de recepción
        /// </summary>
        public DateTime ReceptionDate { get; set; }
        /// <summary>
        /// Nombre del archivo
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Ruta del archivo
        /// </summary>
        public string File { get; set; }
        public CorrespondenceViewDto(){}
    }
}
