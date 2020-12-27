using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public class ProdutosDao : IProdutosDao, IDisposable
    {
        private LojaContext contexto;

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Alterar(Produtos p)
        {
            contexto.Produtos.Update(p);
            contexto.SaveChanges();
        }
        
        public void Excluir(int id)
        {
            var p = contexto.Produtos.Where(x => x.Id == id).FirstOrDefault();
            contexto.Produtos.Remove(p);
            contexto.SaveChanges();
        }

        public void Incluir(Produtos p)
        {
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        public IEnumerable<Produtos> Listar()
        {
            return contexto.Produtos.ToList();
        }
    }
}
