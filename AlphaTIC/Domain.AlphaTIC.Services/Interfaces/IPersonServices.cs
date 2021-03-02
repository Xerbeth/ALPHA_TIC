#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.Services.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos expuestos de los servicios para la tabla Person
    /// </summary>
    public interface IPersonServices
    {
        /// <summary>
        /// Método para obtener la lista de los registros de la tabla Person
        /// </summary>
        /// <returns> Objecto transacción con el resultado de la consulta </returns>
        public TransactionDto<bool> InsPerson(PersonDto person);
    }
}
