#region Referencias 
using System.Collections.Generic;
#endregion Referencias

namespace Domain.AlphaTIC.Common.Data_Transfer_Object
{
    /// <summary>
    /// Clase para el control de errores
    /// </summary>
    public class ErrorAnswerDto
    {
        #region Propiedades
        /// <summary>
        /// Estatus del error
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// Lista de excepciones
        /// </summary>
        public List<ErrorDto> Mistakes { get; set; }
        #endregion Propiedades
        #region Métodos
        /// <summary>
        /// Método constructor
        /// </summary>
        public ErrorAnswerDto() { }
        #endregion Métodos
    }

    /// <summary>
    /// Clase para el error excepción generado
    /// </summary>
    public class ErrorDto
    {
        #region Propiedades
        /// <summary>
        /// Propiedad para el código
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Propiedad para la descripción del error
        /// </summary>
        public string Description { get; set; }
        #endregion Propiedades
        #region Métodos
        /// <summary>
        /// Método constructor
        /// </summary>
        public ErrorDto() { }
        #endregion Método
    }
}
