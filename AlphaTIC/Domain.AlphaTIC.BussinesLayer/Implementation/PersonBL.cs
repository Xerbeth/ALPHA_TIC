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
    public class PersonBL : IPersonBL
    {
        #region Propiedades
        /// <summary>
        /// Interfaces dependencia PersonRepository
        /// </summary>
        private readonly IPersonRepository _personRepository;
        private readonly ILogger<PersonBL> _logger;
        #endregion Propiedades

        #region Métodos

        /// <summary>
        /// Método constructor para inicializar las dependencias
        /// </summary>
        /// <param name="personRepository"> Dependencia para la implementación y acceso a las entidad Person </param>
        public PersonBL(IPersonRepository personRepository, ILogger<PersonBL> logger)
        {
            _personRepository = personRepository;
            _logger = logger;
        }

        /// <summary>
        /// Método para registrar persona
        /// </summary>
        /// <param name="person"> Objeto con la información de la persona a registrar </param>
        /// <returns> Resultado de la transacción </returns>
        public TransactionDto<bool> InsPerson(PersonDto person)
        {
            TransactionDto<bool> transaction = new TransactionDto<bool>();
            transaction.Data = false;
            try
            {
                string _class = MethodBase.GetCurrentMethod().ReflectedType.Name;
                string _method = MethodBase.GetCurrentMethod().Name;
                _logger.LogInformation("Acceso al " + _class +"/"+ _method + " con los siguientes parametros: " + JsonSerializer.Serialize(person));
                PersonModel personModel = new PersonModel();
                personModel.FirstName = person.FirstName;
                personModel.SecondName = person.SecondName;
                personModel.Surname = person.Surname;
                personModel.SecondSurname = person.SecondSurname;
                personModel.BirthDate = person.BirthDate;
                personModel.DocumentTypeId = person.DocumentTypeId;
                personModel.DocumentNumber = person.DocumentNumber;
                personModel.PhoneNumber = person.PhoneNumber;
                personModel.Email = person.Email;
                personModel.CreationDate = DateTime.Now;
                personModel.CreatorPerson = person.CreatorPerson;

                var insPerson = _personRepository.InsPerson(personModel);
                if (!insPerson)
                {
                    transaction.Message = "No existen registrar la persona.";
                    return transaction;
                }

                transaction.Data = true;
                transaction.Message = "Persona registrada correctamente.";
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
