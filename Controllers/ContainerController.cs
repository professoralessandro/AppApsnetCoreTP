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
    public class ContainerController : ControllerCS
    {
        
        [HttpGet]
        public async Task<IActionResult>  ReturnListLivrosWithFilters([FromServices] ContainerServico service,
            Int32? containerId,
            Int32? blId,
            Int32? numero,
            String tipo
            )
        {
            try
            {
                var result = await service.ReturnListContainerWithParameters(containerId, blId, numero, tipo);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Containers>> InsertLivros([FromServices] ContainerServico servico, [FromBody] Containers container)
        {
            try
            {
                return Ok(await servico.InsertContainer(container));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Containers>> UpdateLivros([FromServices] ContainerServico containerServico, Containers container)
        {
            try
            {
                return Ok(await containerServico.UpdateContainer(container));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteLivros([FromServices] ContainerServico ContainerServico, int containerId)
        {
            try
            {
                await ContainerServico.DeleteContainer(containerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}