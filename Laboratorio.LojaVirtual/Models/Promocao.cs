using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public IList<PromocaoProdutos> Produtos { get; set; }

        public Promocao()
        {
            this.Produtos = new List<PromocaoProdutos>();
        }

        public void AddProduto(Produtos p)
        {
            this.Produtos.Add(new PromocaoProdutos
            {
                Produto = p
            });
        }
    }
}
