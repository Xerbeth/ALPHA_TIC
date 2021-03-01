#region Referencias
using Domain.AlphaTIC.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.DAL.Repository.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos de operación expuestos para el acceso a la Base de datos de la entidad DocumentType
    /// </summary>
    public interface IDocumentTypeRepository
    {
        /// <summary>
        /// Método para obtener la lista de los registros de la tabla DocumentType
        /// </summary>
        /// <returns> Modelo de la entidad DocumentType </returns>
        public List<DocumentTypeModel> GetListDocumentType();
    }
}
