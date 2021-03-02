#region Referencias
using Domain.AlphaTIC.BussinesLayer.Interfaces;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Common.Models;
using Domain.AlphaTIC.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
#endregion Referencias

namespace Domain.AlphaTIC.BussinesLayer.Implementation
{
    /// <summary>
    /// Clase para la implementación de la lógica de negocio de la tabla PersonRepository
    /// </summary>
    public class CorrespondenceFilesBL : ICorrespondenceFilesBL
    {
        #region Propiedades               
        private readonly ILogger<CorrespondenceFilesBL> _logger;
        #endregion Propiedades

        #region Métodos

        /// <summary>
        /// Método constructor para inicializar las dependencias
        /// </summary>
        /// <param name="personRepository"> Dependencia para la implementación y acceso a las entidad Person </param>
        public CorrespondenceFilesBL(ILogger<CorrespondenceFilesBL> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método para guardar en el servidor de archivos la documentación
        /// </summary>
        /// <param name="formFile"> Archivo a guardar </param>
        /// <returns> Objeto de la transacción </returns>
        private async Task<TransactionDto<CorrespondenceFilesDto>> AsyncSaveFile(IFormFile formFile)
        {
            TransactionDto<CorrespondenceFilesDto> transaction = new TransactionDto<CorrespondenceFilesDto>();
            transaction.Data = new CorrespondenceFilesDto();
            CorrespondenceFilesDto correspondenceFiles = new CorrespondenceFilesDto();

            if (formFile.Length == 0)
            {
                transaction.Message = "No se cargo ningún archivo.";
                return transaction;
            }

            var estadosPath = DateTime.Now.Year + "\\temporales\\";
            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(formFile.FileName)}";
            var directory = Path.Combine(Environment.CurrentDirectory, estadosPath);
            Directory.CreateDirectory(directory);
            var filePath = Path.Combine(directory, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            correspondenceFiles.Name = formFile.FileName;
            correspondenceFiles.FileType = formFile.ContentType;
            correspondenceFiles.FilePath = filePath;

            transaction.Status = Status.Success;
            transaction.Data = correspondenceFiles;
            transaction.Message = "Guardado del archivo correcto.";
            return transaction;
        }

        /// <summary>
        /// Método para implementar el métod de guardado del archivo temporal en el servidor
        /// </summary>
        /// <param name="formFile"> Archivo a guardar </param>
        /// <returns></returns>
        public TransactionDto<CorrespondenceFilesDto> SaveFile(IFormFile formFile)
        {
            return AsyncSaveFile(formFile).Result;
        }

        #endregion Métodos
    }
}
