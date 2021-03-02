using System;
using System.Collections.Generic;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlphaTIC.API.Controllers
{
    /// <summary>
    /// Endpoint sobre la entidades de Correspondence
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CorrespondenceController : ControllerBase
    {
        private readonly ILogger<CorrespondenceController> _logger;
        private readonly ICorrespondenceServices  _correspondenceServices;

        public CorrespondenceController(ILogger<CorrespondenceController> logger,
                                      ICorrespondenceServices correspondenceServices)
        {
            _logger = logger;
            _correspondenceServices = correspondenceServices;
        }

        /// <summary>
        /// Método para registrar la correspondencia 
        /// </summary>
        /// <param name="correspondence"> Objeto para el registro de la correspondencia </param>
        /// <returns> Resultado de la trasacción </returns>
        [HttpPost("InsCorrespondence")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult InsCorrespondence(CorrespondenceDto correspondence)
        {
            string context = ControllerContext.HttpContext.Request.Path.Value;
            try
            {
                _logger.LogInformation("Acceso al " + context);
                return Ok(_correspondenceServices.InsCorrespondence(correspondence));
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

        /// <summary>
        /// Método para obtener la lista de los tipos de documento
        /// </summary>
        /// <returns> LIsta de tipos de documentos </returns>
        [HttpGet("GetViewCorrespondence")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetViewCorrespondence()
        {
            string context = ControllerContext.HttpContext.Request.Path.Value;
            try
            {
                _logger.LogInformation("Acceso al " + context);
                return Ok(_correspondenceServices.GetViewCorrespondence());
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error en " + context + ".Error: " + ex.Message);
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
