#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.DAL.Repository.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos de operación expuestos para el acceso a la Base de datos de la entidad Person
    /// </summary>
    public interface ICorrespondenceRepository
    {
        /// <summary>
        /// Método para registrar las peronas como remitentes, destinatarios o usuarios del sistema
        /// </summary>
        /// <param name="person"> Entidad persona </param>
        /// <returns> Bandera de creación del usuario </returns>
        public bool InsCorrespondence(CorrespondenceModel correspondence);
        /// <summary>
        /// Método para consultar la vista ViewCorrespondence
        /// </summary>
        /// <returns> Lista de resultados de consultar vista </returns>
        public List<CorrespondenceViewDto> GetViewCorrespondence();
    }
}
