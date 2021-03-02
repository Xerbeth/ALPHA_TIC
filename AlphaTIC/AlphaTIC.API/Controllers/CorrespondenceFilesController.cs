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
    public class CorrespondenceFilesController : ControllerBase
    {
        private readonly ILogger<CorrespondenceFilesController> _logger;
        private readonly ICorrespondenceFilesServices _correspondenceFilesServices;

        public CorrespondenceFilesController(ILogger<CorrespondenceFilesController> logger,
                                      ICorrespondenceFilesServices  correspondenceFilesServices)
        {
            _logger = logger;
            _correspondenceFilesServices = correspondenceFilesServices;
        }

        /// <summary>
        /// Método para obtener la lista de los tipos de documento
        /// </summary>
        /// <returns> Resulta de la transacción </returns>
        [HttpPost("SaveFile")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult SaveFile(IFormFile formFile)
        {
            string context = ControllerContext.HttpContext.Request.Path.Value;
            try
            {
                _logger.LogInformation("Acceso al " + context);
                return Ok(_correspondenceFilesServices.SaveFile(formFile));
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
