using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using basecs.Auxiliar.Padroes;
using basecs.Models;
using basecs.Services;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;

namespace backend_adm.Controllers
{
    //[AllowAnonymous]    
    [Route("api/[controller]")]
    [ApiController]
    public class BlController : ControllerCS
    {
        
        [HttpGet]
        public async Task<IActionResult>  ReturnListBlWithFilters([FromServices] BlServico service,
             Int32? blId,
             String consignatario
            )
        {
            try
            {
                var result = await service.ReturnListBlWithParameters(blId, consignatario);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Bls>> InsertBl([FromServices] BlServico blServico, [FromBody] Bls Bl)
        {
            try
            {
                return Ok(await blServico.InsertBl(Bl));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Bls>> UpdateBl([FromServices] BlServico blServico, Bls Bl)
        {
            try
            {
                return Ok(await blServico.UpdateBl(Bl));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Bls>> DeleteBl([FromServices] BlServico BlServico, int blId)
        {
            try
            {
                await BlServico.DeleteBl(blId);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}