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
    public class ProdutoController : ControllerCS
    {

        [HttpGet]
        public async Task<IActionResult> ReturnListProdutosWithFilters([FromServices] ProdutoServico service,
             int? id,
             string nome,
             Boolean? ativo
            )
        {
            try
            {
                var result = await service.ReturnListProdutosWithParameters(id, nome, ativo);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> ReturnListProdutosWithFilters([FromServices] ProdutoServico service, int id
            )
        {
            try
            {
                var result = await service.FindProdutosByProdutosId(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> InsertProdutos([FromServices] ProdutoServico ProdutoServico, [FromBody] Produto produto)
        {
            try
            {
                return Ok(await ProdutoServico.InsertProduto(produto));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Produto>> UpdateProdutos([FromServices] ProdutoServico ProdutoServico, Produto produto)
        {
            try
            {
                return Ok(await ProdutoServico.UpdateProduto(produto));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteProdutos([FromServices] ProdutoServico servico, int id)
        {
            try
            {
                await servico.DeleteProduto(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}