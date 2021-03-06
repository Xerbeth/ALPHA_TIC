﻿#region Referencias
using System;
#endregion Referenias

namespace Domain.AlphaTIC.Common.Models
{
    /// <summary>
    /// Clase para las propiedades de auditoria de los modelos/entidades
    /// </summary>
    public class AuditModel
    {
        #region Propiedades
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
        public AuditModel() { }
        #endregion Métodos
    }
}
