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
    public class PersonServices : IPersonServices
    {
        #region Propiedades
        private readonly IPersonBL _personBL;
        #endregion Propiedades

        #region Métodos 
        /// <summary>
        /// Método constructor 
        /// </summary>
        /// <param name="documentTypeBL"></param>
        public PersonServices(IPersonBL personBL)
        {
            _personBL = personBL;
        }

        /// <summary>
        /// Método para insertar un registro de la tabla person
        /// </summary>
        /// <param name="person"> Objeto persona </param>
        /// <returns> Objecto resultado de la transacción </returns>
        public TransactionDto<bool> InsPerson(PersonDto person)
        {
            return _personBL.InsPerson(person);
        }
        #endregion Métodos
    }
}
