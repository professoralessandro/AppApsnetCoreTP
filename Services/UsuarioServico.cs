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
    public class UsuarioServico
    {
        private MyDbContext _context;

        public UsuarioServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> FindUsuariosByUsuariosId(int id)
        {
            try
            {
                return await this._context.Usuarios.SingleOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Usuario." + ex.Message);
            }
        }
        public async Task<List<Usuario>> ReturnListUsuariosWithParameters(
            int? id,
            string nome,
            Boolean? ativo
            )
        {
            try
            {
                List<Usuario> lstUsuarios = await _context.Usuarios.Where(c => (c.Id == id || id == null) &&
                   (c.Nome.Contains(nome) || nome == null) &&
                   (c.Ativo == ativo || ativo == null)
                   ).ToListAsync();

                return lstUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Usuario: " + ex.Message);
            }

        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            try
            {
                if (usuario.Id == 0)
                    throw new KeyNotFoundException("Id");
                this._context.Update(usuario);
                await this._context.SaveChangesAsync();
                return usuario;
            }
            catch (KeyNotFoundException key)
            {
                throw new Exception("Um campo necessário para essa ação não foi informado: " + key.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar editar o registro: " + ex.Message);
            }
        }
        public async Task<Usuario> InsertUsuario(Usuario usuario)
        {
            try
            {
                using (var context = this._context)
                {
                    context.Usuarios.Add(usuario);
                    await context.SaveChangesAsync();
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Usuario: " + ex.Message);
            }
        }
        public async Task<Usuario> DeleteUsuario(int id)
        {
            try
            {
                if (id == 0)
                    throw new KeyNotFoundException("Usuario");

                Usuario usuario = await this.FindUsuariosByUsuariosId(id);

                usuario.Ativo = false;

                await this.UpdateUsuario(usuario);

                return usuario;
            }
            catch (KeyNotFoundException key)
            {
                throw new Exception("Um campo necessário para essa ação não foi informado: " + key.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar deletar o registro: " + ex.Message);
            }
        }
    }
}