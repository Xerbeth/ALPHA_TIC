#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.Services.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos expuestos de los servicios para la tabla Corresponde
    /// </summary>
    public interface ICorrespondenceServices
    {
        /// <summary>
        /// Método para registrar la correspondencia
        /// </summary>
        /// <param name="correspondence"> Objeto con la información de la correspondencia a registrar </param>
        /// <returns> Objeto de la transacción </returns>
        public TransactionDto<bool> InsCorrespondence(CorrespondenceDto correspondence);
        /// <summary>
        /// Métod para consultar la vista de correspondence
        /// </summary>
        /// <returns> Objeto de la transacción </returns>
        public TransactionDto<List<CorrespondenceViewDto>> GetViewCorrespondence();
    }
}
