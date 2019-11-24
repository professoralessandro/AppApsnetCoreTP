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
    public class AutorController : ControllerCS
    {
        
        [HttpGet]
        public async Task<IActionResult> ReturnListAutoresWithFilters([FromServices] AutoresServico service,
             int? id,
             string titulo,
             string autor
            )
        {
            try
            {
                var result = await service.ReturnListAutoresWithParameters(id, titulo, autor);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Autores>> InsertAutores([FromServices] AutoresServico AutoresServico, [FromBody] Autores Autores)
        {
            try
            {
                return Ok(await AutoresServico.InsertAutor(Autores));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Autores>> UpdateAutores([FromServices] AutoresServico AutoresServico, Autores Autores)
        {
            try
            {
                return Ok(await AutoresServico.UpdateAutor(Autores));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAutores([FromServices] AutoresServico AutoresServico, int id)
        {
            try
            {
                await AutoresServico.DeleteAutor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}