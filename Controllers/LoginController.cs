using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using basecs.Auxiliar.Exceptions;
using basecs.Auxiliar.Padroes;
using basecs.Models;
using basecs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace basecs.Controllers {
    [Route ("api/[controller]")]
    public class LoginController : ControllerCS {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<bool>> Post(
            [FromBody] Usuario usuario, [FromServices] LoginServico service) {
            try {
                Usuario usuario1 = new Usuario();

                //bool credenciaisValidas = false;

                //return Ok(service.AuthUsuario(usuario.Nome, usuario.Senha));

                //return Ok(service.ReturnListUsuariosWithParameters(null,null, null));

                usuario1 = await service.AuthUsuario(usuario.Nome, usuario.Senha);

                if(String.IsNullOrEmpty(usuario1.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            } catch (Exception ex) {
                return UnprocessableEntity(ex.Message);
            }
        }

        // [AllowAnonymous]
        // [HttpPost]
        // [Route("recupera")]
        // public ActionResult<Resultado> RecuperaSenha([FromBody] Usuarios usuario,
        //     [FromServices]UsuarioServico usrServico)
        // {
        //     Resultado resultado = new Resultado
        //     {
        //         Acao = "Recuperar senha de usuário."
        //     };

        //     try
        //     {
        //         if (string.IsNullOrEmpty(usuario.Usuario) || usuario == null)
        //         {
        //             resultado.Inconsistencias.Add("Informe o usuário.");
        //             throw new ListStringException();
        //         }

        //         usuario = usrServico.BuscarPorNomeOuEmail(usuario.Usuario);

        //         if(usuario == null)
        //         {
        //             resultado.Inconsistencias.Add("Usuário não encontrado na base de dados.");
        //             throw new ListStringException();
        //         }

        //         //Gerar uma nova senha

        //         usrServico.RecuperaSenha(usuario);
        //         usrServico.Update(usuario);
        //     }
        //     catch (ListStringException ex)
        //     {
        //         ex.TaskExceptions.ForEach(c =>
        //         {
        //             resultado.Inconsistencias.Add(c.Message);
        //         });

        //         return UnprocessableEntity(resultado);
        //     }

        //     return resultado;
        // }

        // [AllowAnonymous]
        // [HttpPost]
        // [Route("trocasenha")]
        // public ActionResult<Resultado> TrocaSenha([FromBody] Usuario usuario,
        //     [FromServices]UsuarioServico usrServico
        // {
        //     Resultado resultado = new Resultado
        //     {
        //         Acao = "Altera Senha de Usuario."
        //     };

        //     try
        //     {
        //         Usuario user2 = new Usuario();

        //         if (string.IsNullOrEmpty(usuario.UsuarioNick) || usuario == null)
        //         {
        //             resultado.Inconsistencias.Add("Informe UsuarioNick.");
        //             throw new ListStringException();
        //         }

        //         if (string.IsNullOrEmpty(usuario.Senha) || usuario == null)
        //         {
        //             resultado.Inconsistencias.Add("Informe Senha.");
        //             throw new ListStringException();
        //         }

        //         user2 = usrServico.BuscarPorNomeOuEmail(usuario.UsuarioNick, UsuarioIdPrincipal);

        //         if(user2 == null)
        //         {
        //             resultado.Inconsistencias.Add("Usuário não encontrado na base.");
        //             throw new ListStringException();
        //         }

        //         //Gerar uma nova senha
        //         user2.Senha = usuario.Senha;
        //         user2.TrocaSenha = false;

        //         usrServico.Update(user2);

        //         StringBuilder sbMail = new StringBuilder();

        //         sbMail.Append("<html>");
        //         sbMail.Append("<table>");
        //         sbMail.Append("<tr><td>Este é um e-mail automático, por favor, não responda.</td></tr>");
        //         sbMail.Append("<tr><td>&nbsp;</td></tr>");
        //         sbMail.Append("</table>");
        //         sbMail.Append("<table>");
        //         sbMail.Append("<tr>");
        //         sbMail.Append(string.Format("<td>Prezado(a): {0}</td>", user2.Nome));
        //         sbMail.Append("</tr>");
        //         sbMail.Append("</table>");
        //         sbMail.Append("<table>");
        //         sbMail.Append("<tr>");
        //         sbMail.Append(string.Format("<td>Sua senha foi alterada com sucesso. </td>", user2.Senha));
        //         sbMail.Append("</tr>");
        //         sbMail.Append("</table>");
        //         sbMail.Append("</html>");

        //         //Enviar e-mail com a nova senha
        //         Email email = new Email()
        //         {
        //             Assunto = "Alterção de Senha",
        //             Destinatarios = user2.Email + "|" + user2.Nome,
        //             UrlAttach = "",
        //             Tentativas = 0,
        //             EmailTipoId = 1,
        //             Enviado = false,
        //             Html = true,
        //             Mensagem = sbMail.ToString()
        //         };

        //         emailServico.Insert(email, UsuarioIdPrincipal);
        //     }
        //     catch (ListStringException ex)
        //     {
        //         ex.TaskExceptions.ForEach(c =>
        //         {
        //             resultado.Inconsistencias.Add(c.Message);
        //         });

        //         return UnprocessableEntity(resultado);
        //     }

        //     return resultado;
        // }
    }

}