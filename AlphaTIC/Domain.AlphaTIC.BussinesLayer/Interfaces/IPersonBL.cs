#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.BussinesLayer.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos expuestos de la logica de negocio para la tabla Person
    /// </summary>
    public interface IPersonBL
    {
        /// <summary>
        /// Método para insertar una persona
        /// </summary>
        /// <param name="person"> Objeto persona </param>
        /// <returns> Resultado de la transacción </returns>
        public TransactionDto<bool> InsPerson(PersonDto person);
    }
}
