using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AlphaTIC.Common.Models
{
    public class CorrespondenceFilesModel : AuditModel
    {
        #region Propiedades
        /// <summary>
        /// Nombre del archivo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Tipo de archivo
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// Ruta absoluta del archivo en servidor/gestor archivos
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Identificador de correspondencia 
        /// </summary>
        public int CorrespondenceId { get; set; }
        #endregion Propiedades
        #region Métodos
        /// <summary>
        /// Método constructor
        /// </summary>
        public CorrespondenceFilesModel() { }
        #endregion Métodos
    }
}
