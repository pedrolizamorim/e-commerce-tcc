using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PadawanStore.Domain.Entities;
using PadawanStore.Infra.Data.Context;
using PadawanStore.Infra.Data.Interface;

namespace PadawanStore.Infra.Data.Repositories
{
    public class PedidoProdutoRepository : IPedidoProdutoRepository
    {
        private readonly StoreContext _context;

        public PedidoProdutoRepository(StoreContext context)
        {
            _context = context;
        }

        public PedidoProduto ObterPeloId(int id)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.Id == id)
            .FirstOrDefault();
        }

        public List<PedidoProduto> ObterTodosPeloPedido(int idPedido)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.IdPedido == idPedido)
            .ToList();
        }

        public List<PedidoProduto> ObterTodosPeloProduto(int idProduto)
        {
            return _context.PedidoProdutos
            .Include(x => x.Pedido)
            .Include(x => x.Produto)
            .Where(x => x.RegistroAtivo && x.IdProduto == idProduto)
            .ToList();
        }
    }
}