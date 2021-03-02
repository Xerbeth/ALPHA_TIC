#region Referencias
using Domain.AlphaTIC.BussinesLayer.Interfaces;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
#endregion Referencias

namespace Domain.AlphaTIC.Services.Implementation
{
    /// <summary>
    /// Clase para la implementación de los servicios de la tabla DocumentType
    /// </summary>
    public class CorrespondenceFilesServices : ICorrespondenceFilesServices
    {
        #region Propiedades
        private readonly ICorrespondenceFilesBL  _correspondenceFilesBL;
        #endregion Propiedades

        #region Métodos 
        /// <summary>
        /// Método constructor 
        /// </summary>
        /// <param name="correspondenceFilesBL"> Inyección del bl </param>
        public CorrespondenceFilesServices(ICorrespondenceFilesBL correspondenceFilesBL)
        {
            _correspondenceFilesBL = correspondenceFilesBL;
        }

        /// <summary>
        /// Método para guardar el archivo en el servidor de documentos
        /// </summary>
        /// <param name="formFile"> Archivo a guardar </param>
        /// <returns> Objecto de la transacción </returns>
        public TransactionDto<CorrespondenceFilesDto> SaveFile(IFormFile formFile)
        {
            return _correspondenceFilesBL.SaveFile(formFile);
        }        
        #endregion Métodos
    }
}
