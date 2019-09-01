using System;
using System.Collections.Generic;
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
    public class LivrosController : ControllerCS
    {
        
        [HttpGet]
        public IActionResult ReturnListLivrosWithFilters([FromServices] LivrosServico service,
             int? livroId,
             string nome,
             Double preco
            )
        {
            try
            {
                var result = service.ReturnListLivrosWithParameters(livroId, nome);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Livros> InsertLivros([FromServices] LivrosServico LivrosServico, [FromBody] Livros Livros)
        {
            try
            {
                return Ok(LivrosServico.InsertLivro(Livros));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Livros> UpdateLivros([FromServices] LivrosServico LivrosServico, Livros Livros)
        {
            try
            {
                return Ok(LivrosServico.UpdateLivro(Livros));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        /*
        [HttpDelete]
        public ActionResult DeleteLivros([FromServices] LivrosServico LivrosServico, int livroId)
        {
            try
            {
                LivrosServico.DeleteLivro(livroId);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        */
    }
}