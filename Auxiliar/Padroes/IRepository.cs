using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basecs.Auxiliar.Padroes;

namespace basecs.Auxiliar.Padroes
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(long id);
        long Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
