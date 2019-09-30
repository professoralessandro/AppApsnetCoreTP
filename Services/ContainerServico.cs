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
    public class ContainerServico
    {
        private MyDbContext _context;

        public ContainerServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Containers> FindContainerByContainersId(int containerId)
        {
            try
            {
                return this._context.Containers.SingleOrDefault(c => c.ContainerId == containerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Autor." + ex.Message);
            }
        }
        public async Task<List<Containers>> ReturnListContainerWithParameters(
        Int32? containerId,
        Int32? blId,
        Int32? numero,
        String tipo)
        {
            try
            {

                List<Containers> lstContainers = await _context.Containers.Where(c => (c.ContainerId == containerId || containerId == null) &&
                   (c.Numero == numero || numero == null) &&
                   (c.BlId == blId || blId == null) &&
                   (c.Tipo.Contains(tipo) || tipo == null)).ToListAsync();

                return lstContainers;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Autor: " + ex.Message);
            }

        }

        public async Task<Containers> UpdateContainer(Containers container)
        {
            try
            {
                if (container.ContainerId == 0)
                    throw new KeyNotFoundException("AutorId");
                this._context.Update(container);
                this._context.SaveChanges();
                return container;
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
        public async Task<Containers> InsertContainer(Containers autors)
        {
            try
            {
                using (var context = this._context)
                {
                    context.Containers.Add(autors);
                    context.SaveChanges();
                    return autors;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Autor: " + ex.Message);
            }
        }
        public async Task<Containers> DeleteContainer(int containerId)
        {
            try
            {
                if (containerId == 0)
                    throw new KeyNotFoundException("Containers");

                Containers container = await this.FindContainerByContainersId(containerId);

                using (var context = this._context)
                {
                    context.Containers.Remove(container);
                    context.SaveChanges();
                    return container;
                }
            }
            catch (KeyNotFoundException key)
            {
                throw new Exception("Um campo necessário para essa ação não foi informado: " + key.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar deletar o registro: " + ex.Message);
            }
        }//DELETAR
    }
}