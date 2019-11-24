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
    public class ListaController : ControllerCS
    {
        
        [HttpGet]
        public async Task<IActionResult> ReturnListListasWithFilters([FromServices] ListasServico service,
             int? id,
             string nome
            )
        {
            try
            {
                var result = await service.ReturnListListasWithParameters(id, nome);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Listas>> InsertListas([FromServices] ListasServico ListasServico, [FromBody] Listas Listas)
        {
            try
            {
                return Ok(await ListasServico.InsertLista(Listas));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Listas>> UpdateListas([FromServices] ListasServico ListasServico, Listas Listas)
        {
            try
            {
                return Ok(await ListasServico.UpdateLista(Listas));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteListas([FromServices] ListasServico ListasServico, int id)
        {
            try
            {
                await ListasServico.DeleteLista(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}