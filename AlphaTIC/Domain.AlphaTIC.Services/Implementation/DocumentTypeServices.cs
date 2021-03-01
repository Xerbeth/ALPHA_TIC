#region Referencias
using Domain.AlphaTIC.BussinesLayer.Interfaces;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Services.Interfaces;
using System;
using System.Collections.Generic;
#endregion Referencias

namespace Domain.AlphaTIC.Services.Implementation
{
    /// <summary>
    /// Clase para la implementación de los servicios de la tabla DocumentType
    /// </summary>
    public class DocumentTypeServices : IDocumentTypeServices
    {
        #region Propiedades
        private readonly IDocumentTypeBL _documentTypeBL;
        #endregion Propiedades

        #region Métodos 
        /// <summary>
        /// Método constructor 
        /// </summary>
        /// <param name="documentTypeBL"></param>
        public DocumentTypeServices(IDocumentTypeBL documentTypeBL)
        {
            _documentTypeBL = documentTypeBL;
        }

        /// <summary>
        /// Método para obtener la lista de los registros de la tabla DocumentType
        /// </summary>
        /// <returns> Objecto transacción con el resultado de la consulta </returns>
        public TransactionDto<List<DocumentTypeDto>> GetListDocumentType()
        {
            return _documentTypeBL.GetListDocumentType();
        }
        #endregion Métodos
    }
}
