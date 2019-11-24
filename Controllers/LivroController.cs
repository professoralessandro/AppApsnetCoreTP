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
    public class LivroController : ControllerCS
    {

        [HttpGet]
        public async Task<IActionResult> ReturnListLivrosWithFilters([FromServices] LivrosServico service,
             int? id,
             string titulo,
             string autor
            )
        {
            try
            {
                var result = await service.ReturnListLivrosWithParameters(id, titulo, autor);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> ReturnListLivrosWithFilters([FromServices] LivrosServico service, int id
            )
        {
            try
            {
                var result = await service.FindLivrosByLivrosId(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Livros>> InsertLivros([FromServices] LivrosServico LivrosServico, [FromBody] Livros Livros)
        {
            try
            {
                return Ok(await LivrosServico.InsertLivro(Livros));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Livros>> UpdateLivros([FromServices] LivrosServico LivrosServico, Livros Livros)
        {
            try
            {
                return Ok(await LivrosServico.UpdateLivro(Livros));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteLivros([FromServices] LivrosServico LivrosServico, int id)
        {
            try
            {
                await LivrosServico.DeleteLivro(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}