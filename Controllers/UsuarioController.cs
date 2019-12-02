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
    public class UsuarioController : ControllerCS
    {

        [HttpGet]
        public async Task<IActionResult> ReturnListUsuariosWithFilters([FromServices] UsuarioServico service,
             int? id,
             string nome,
             Boolean? ativo
            )
        {
            try
            {
                var result = await service.ReturnListUsuariosWithParameters(id, nome, ativo);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> ReturnListUsuariosWithFilters([FromServices] UsuarioServico service, int id
            )
        {
            try
            {
                var result = await service.FindUsuariosByUsuariosId(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> InsertUsuarios([FromServices] UsuarioServico UsuarioServico, [FromBody] Usuario usuario)
        {
            try
            {
                return Ok(await UsuarioServico.InsertUsuario(usuario));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateUsuarios([FromServices] UsuarioServico UsuarioServico, Usuario usuario)
        {
            try
            {
                return Ok(await UsuarioServico.UpdateUsuario(usuario));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUsuarios([FromServices] UsuarioServico servico, int id)
        {
            try
            {
                await servico.DeleteUsuario(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}