using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.AlphaTIC.Common.Data_Transfer_Object;
using Domain.AlphaTIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlphaTIC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeServices _documentTypeServices;

        public DocumentTypeController(IDocumentTypeServices documentTypeServices)
        {
            _documentTypeServices = documentTypeServices;
        }

        /// <summary>
        /// Método para obtener la lista de los tipos de documento
        /// </summary>
        /// <returns> LIsta de tipos de documentos </returns>
        [HttpGet("GetListDocumentType")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetListDocumentType()
        {
            try
            {
                return Ok(_documentTypeServices.GetListDocumentType());
            }
            catch (Exception ex)
            {
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
