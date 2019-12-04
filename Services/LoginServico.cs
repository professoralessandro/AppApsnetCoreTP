using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basecs.Auxiliar.Padroes;
using basecs.Data;
using basecs.Models;
using basecs.Services;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class LoginServico
    {
        private MyDbContext _context;

        public LoginServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AuthUsuario(
            string nome,
            string senha
            )
        {
            try
            {
                Usuario usuario = await _context.Usuarios.Where(c =>
                   (c.Nome.Contains(nome)) &&
                   (c.Senha.Contains(senha)) &&
                   (c.Ativo.Equals(true))
                   ).FirstOrDefaultAsync();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Usuario: " + ex.Message);
            }
        }
    }
}