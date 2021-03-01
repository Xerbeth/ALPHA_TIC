#region Referencias
using Domain.AlphaTIC.BussinesLayer.Interfaces;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
#endregion Referencias

namespace Domain.AlphaTIC.BussinesLayer.Implementation
{
    /// <summary>
    /// Clase para la implementación de la lógica de negocio de la tabla DocumentType
    /// </summary>
    public class DocumentTypeBL : IDocumentTypeBL
    {
        #region Propiedades
        /// <summary>
        /// Interfaces dependencia DocumentType
        /// </summary>
        private readonly IDocumentTypeRepository _documentTypeRepository;
        #endregion Propiedades

        #region Métodos

        /// <summary>
        /// Métod constructor para inicializar las dependencias
        /// </summary>
        /// <param name="documentTypeRepository"> Dependencia para la implementación y acceso a las entidad DocumentType </param>
        public DocumentTypeBL(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        /// <summary>
        /// Método para obtener la lista de los registros de la tabla DocumentType
        /// </summary>
        /// <returns> Objecto transacción con el resultado de la consulta </returns>
        public TransactionDto<List<DocumentTypeDto>> GetListDocumentType()
        {
            TransactionDto<List<DocumentTypeDto>> transaction = new TransactionDto<List<DocumentTypeDto>>();
            transaction.Data = new List<DocumentTypeDto>();
            try
            {
                var getListDocumentType = _documentTypeRepository.GetListDocumentType();
                if (getListDocumentType.Count == 0)
                {
                    transaction.Message = "No existen registros.";
                    return transaction;
                }
                foreach (var item in getListDocumentType)
                {
                    DocumentTypeDto documentType = new DocumentTypeDto();
                    documentType.Id = item.Id;
                    documentType.Name = item.Name;
                    documentType.Code = item.Code;
                    transaction.Data.Add(documentType);
                }
                transaction.Message = "Datos consultados correctamente.";
                transaction.Status = Status.Success;
            }
            catch (ArgumentException ex)
            {
                transaction.Message = ex.Message;
            }

            return transaction;
        }
        #endregion Métodos
    }
}
