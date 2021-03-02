using System;
using System.Collections.Generic;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlphaTIC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorrespondenceController : ControllerBase
    {
        private readonly ILogger<CorrespondenceController> _logger;
        private readonly IDocumentTypeServices _documentTypeServices;

        public CorrespondenceController(ILogger<CorrespondenceController> logger, 
                                      IDocumentTypeServices documentTypeServices)
        {
            _logger = logger;
            _documentTypeServices = documentTypeServices;
        }

        /// <summary>
        /// Método para obtener la lista de los tipos de documento
        /// </summary>
        /// <returns> LIsta de tipos de documentos </returns>
        [HttpGet("InsCorrespondence")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetListDocumentType()
        {
            string context = ControllerContext.HttpContext.Request.Path.Value;
            try
            {
                _logger.LogInformation("Acceso al " + context);
                return Ok(_documentTypeServices.GetListDocumentType());
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
