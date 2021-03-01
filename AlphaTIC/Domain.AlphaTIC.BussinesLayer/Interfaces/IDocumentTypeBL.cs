#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.BussinesLayer.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos expuestos de la logica de negocio para la tabla DocumentType
    /// </summary>
    public interface IDocumentTypeBL
    {
        /// <summary>
        /// Método para obtener la lista de los registros de la tabla DocumentType
        /// </summary>
        /// <returns> Objecto transacción con el resultado de la consulta </returns>
        public TransactionDto<List<DocumentTypeDto>> GetListDocumentType();
    }
}
