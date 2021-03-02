#region Referencias
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
#endregion Referencias

namespace Domain.AlphaTIC.BussinesLayer.Interfaces
{
    /// <summary>
    /// Interfaces para la definición de los métodos expuestos de la logica de negocio para la tabla Correspondence
    /// </summary>
    public interface ICorrespondenceFilesBL
    {
        /// <summary>
        /// Método para guardar en el gestor de archivos la documentación
        /// </summary>
        /// <param name="formFile"> Archivo a guardar </param>
        /// <returns> Resultado de la transaccion </returns>
        public TransactionDto<CorrespondenceFilesDto> SaveFile(IFormFile formFile);
    }
}
