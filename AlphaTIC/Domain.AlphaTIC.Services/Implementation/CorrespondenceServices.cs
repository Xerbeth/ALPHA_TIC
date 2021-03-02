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
    public class CorrespondenceServices : ICorrespondenceServices
    {
        #region Propiedades
        private readonly ICorrespondenceBL  _correspondenceBL;
        #endregion Propiedades

        #region Métodos 
        /// <summary>
        /// Método constructor 
        /// </summary>
        /// <param name="correspondenceBL"> Inyección del bl </param>
        public CorrespondenceServices(ICorrespondenceBL correspondenceBL)
        {
            _correspondenceBL = correspondenceBL;
        }

        /// <summary>
        /// Método para registrar la correspondencia
        /// </summary>
        /// <param name="correspondence"> Objeto con la información de la correspondencia a registrar </param>
        /// <returns> Objeto de la transacción </returns>
        public TransactionDto<bool> InsCorrespondence(CorrespondenceDto correspondence)
        {
            return _correspondenceBL.InsCorrespondence(correspondence);
        }
        #endregion Métodos
    }
}
