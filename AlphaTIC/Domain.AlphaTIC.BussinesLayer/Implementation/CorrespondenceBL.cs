#region Referencias
using Domain.AlphaTIC.BussinesLayer.Interfaces;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Common.Models;
using Domain.AlphaTIC.DAL.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Text.Json;
#endregion Referencias

namespace Domain.AlphaTIC.BussinesLayer.Implementation
{
    /// <summary>
    /// Clase para la implementación de la lógica de negocio de la tabla PersonRepository
    /// </summary>
    public class CorrespondenceBL : ICorrespondenceBL
    {
        #region Propiedades
        /// <summary>
        /// Interfaces dependencia PersonRepository
        /// </summary>
        private readonly ICorrespondenceRepository _correspondenceRepository;
        private readonly ILogger<CorrespondenceBL> _logger;
        #endregion Propiedades

        #region Métodos

        /// <summary>
        /// Método constructor para inicializar las dependencias
        /// </summary>
        /// <param name="personRepository"> Dependencia para la implementación y acceso a las entidad Person </param>
        public CorrespondenceBL(ICorrespondenceRepository correspondenceRepository, ILogger<CorrespondenceBL> logger)
        {
            _correspondenceRepository = correspondenceRepository;
            _logger = logger;
        }

        /// <summary>
        /// Método para registrar persona
        /// </summary>
        /// <param name="person"> Objeto con la información de la persona a registrar </param>
        /// <returns> Resultado de la transacción </returns>
        public TransactionDto<bool> InsCorrespondence(CorrespondenceDto correspondence)
        {
            TransactionDto<bool> transaction = new TransactionDto<bool>();
            transaction.Data = false;
            try
            {
                string _class = MethodBase.GetCurrentMethod().ReflectedType.Name;
                string _method = MethodBase.GetCurrentMethod().Name;
                _logger.LogInformation("Acceso al " + _class +"/"+ _method + " con los siguientes parametros: " + JsonSerializer.Serialize(correspondence));
                CorrespondenceModel correspondenceModel = new CorrespondenceModel();
                correspondenceModel.Description = correspondence.Description;
                correspondenceModel.TypeCorrespondence = correspondence.TypeCorrespondence;
                correspondenceModel.SenderId = correspondence.SenderId;
                correspondenceModel.AddresseeId = correspondence.AddresseeId;
                correspondenceModel.CreatorPerson = correspondence.CreatorPerson;
                correspondenceModel.CreationDate = DateTime.Now;

                var insCorrespondence = _correspondenceRepository.InsCorrespondence(correspondenceModel);
                if (!insCorrespondence)
                {
                    transaction.Message = "No existen registrar la correspondencia.";
                    return transaction;
                }

                transaction.Data = true;
                transaction.Message = "Correspondencia registrada correctamente.";
                transaction.Status = Status.Success;
            }
            catch (ArgumentException ex)
            {
                transaction.Message = ex.Message;
            }

            return transaction;
        }
        #endregion Métodos
    }
}
