using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RESTArchExample.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.ServiceLayer.controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryManagementController : ControllerBase
    {

        #region Protected Attributes

        private readonly IConfiguration _configuration;

        private readonly IMediator _mediator;


        #endregion

        #region Constructors

        public InventoryManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #endregion



        #region Public Attributes


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    // Lógica del método GET
        //    return Ok("¡Hola desde InventoryManagementController!");
        //}

        [HttpPost("CreateCarModel")]
        public async Task<IActionResult> CreateCarModel([FromBody] CreateCarModelReqDTO createCarModelDTO)
        {
            try
            {

                GenericResponse result = await _mediator.Send(createCarModelDTO);

                if (result != null && result.success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.error);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"CRITICAL error processing the car model creation: {ex.Message}");
            
            
            }
        }


        [HttpGet("GetCarModels")]
        public async Task<IActionResult> GetCarModels([FromQuery] GetCarModelReqDTO requestDTO)
        {
            try
            {

                // Utiliza Send en lugar de Publish
                GenericResponse result = await _mediator.Send(requestDTO);

                // Puedes manejar el resultado y devolver una respuesta adecuada
                if (result != null && result.success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.error);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"CRITICAL error processing the car model creation: {ex.Message}");


            }
        }


        #endregion
    }
}
