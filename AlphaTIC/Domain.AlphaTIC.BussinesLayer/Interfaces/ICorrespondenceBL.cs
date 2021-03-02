#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.BussinesLayer.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos expuestos de la logica de negocio para la tabla Correspondence
    /// </summary>
    public interface ICorrespondenceBL
    {
        /// <summary>
        /// Método para registrar la correspondencia
        /// </summary>
        /// <param name="correspondence"> Objeto con la información de la correspondencia a registrar </param>
        /// <returns> Objeto de la transacción </returns>
        public TransactionDto<bool> InsCorrespondence(CorrespondenceDto correspondence);
        /// <summary>
        /// Método para consultar la vista ViewCorrespondence
        /// </summary>
        /// <returns> Lista de resultados de consultar vista </returns>
        public TransactionDto<List<CorrespondenceViewDto>> GetViewCorrespondence();
    }
}
