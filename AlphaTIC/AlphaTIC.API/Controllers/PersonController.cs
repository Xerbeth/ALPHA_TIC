using System;
using System.Collections.Generic;
using System.Text.Json;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlphaTIC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonServices _personServices;

        public PersonController(ILogger<PersonController> logger,
                                IPersonServices personServices)
        {
            _logger = logger;
            _personServices = personServices;
        }

        /// <summary>
        /// Método para registrar personas
        /// </summary>
        /// <param name="person"> Objeto persona </param>
        /// <returns> Resultado de la transacción </returns>
        [HttpPost("InsPerson")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult InsPerson(PersonDto person)
        {
            string context = ControllerContext.HttpContext.Request.Path.Value;
            try
            {
                _logger.LogInformation("Acceso al " + context + "con los siguientes parametros : " + JsonSerializer.Serialize(person));
                return Ok(_personServices.InsPerson(person));
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error en "+ context + ".Error: "+ ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorAnswerDto()
                {
                    State = StatusCodes.Status400BadRequest,
                    Mistakes = new List<ErrorDto>(new[]
                    {
                         new ErrorDto()
                         {
                             Code = "",
                             Description = ex.Message
                         }
                     })
                });
            }
        }
    }
}
