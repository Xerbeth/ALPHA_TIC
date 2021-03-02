#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.Services.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos expuestos de los servicios para la tabla Correspondence_Files
    /// </summary>
    public interface ICorrespondenceFilesServices
    {
        /// <summary>
        /// Método para guardare el archivo
        /// </summary>
        /// <param name="correspondence"> Archivo para guardar </param>
        /// <returns> Objeto de la transacción </returns>
        public TransactionDto<CorrespondenceFilesDto> SaveFile(IFormFile formFile);
    }
}
