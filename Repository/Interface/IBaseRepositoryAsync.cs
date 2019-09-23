using PadawanStore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PadawanStore.Infra.Data.Interface
{
    public interface IBaseRepositoryAsync<T> where T : Base
    {
        Task<int> Adicionar(T entity);

        bool Alterar(T entity);

        bool Apagar(int id);

        List<T> ObterTodos();

        T ObterPeloId(int id);
    }
}