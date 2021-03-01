#region Referencias
#endregion Referencias

namespace Domain.AlphaTIC.Common.Data_Transfer_Object
{
    /// <summary>
    /// Clase para mostrar la información relevante de la tabla DocumentType
    /// </summary>
    public class DocumentTypeDto
    {
        #region Propiedades
        /// <summary>
        /// Propiedad para el identificador del registro
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Propiedad para el nombre del tipo de documento
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Propiedad para el código unico del registro
        /// </summary>
        public string Code { get; set; }
        #endregion Propiedades

        #region Métodos
        /// <summary>
        /// Métodod constructor
        /// </summary>
        public DocumentTypeDto() { }
        #endregion Métodos
    }
}
