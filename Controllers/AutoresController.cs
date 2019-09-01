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
    public class AutoresController : ControllerCS
    {
        
        [HttpGet]
        public IActionResult ReturnListAutoresWithFilters([FromServices] AutoresServico service,
            Int32? autorId,
            string nome,
            string email
            )
        {
            try
            {
                var result = service.ReturnListAutoresWithParameters(autorId, nome, email);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Autores> InsertAutores([FromServices] AutoresServico AutoresServico, [FromBody] Autores Autores)
        {
            try
            {
                return Ok(AutoresServico.InsertAutor(Autores));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Autores> UpdateAutores([FromServices] AutoresServico AutoresServico, Autores Autores)
        {
            try
            {
                return Ok(AutoresServico.UpdateAutor(Autores));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        /*
        [HttpDelete]
        public ActionResult DeleteAutores([FromServices] AutoresServico AutoresServico, int livroId)
        {
            try
            {
                AutoresServico.DeleteAutor(livroId);
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