using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public class Produtos
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; internal set; }
        public IList<PromocaoProdutos> Promocoes { get; set; }
        public IList<Compra> Compras { get; set; }

        public override string ToString()
        {
            return $"Nome: {this.Nome}";
        }
    }
}
