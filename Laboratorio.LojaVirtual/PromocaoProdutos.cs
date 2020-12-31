using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public class PromocaoProdutos
    {
        public int ProdutoId { get; set; }
        public Produtos Produto { get; set; }
        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
    }
}
