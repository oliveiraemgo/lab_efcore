using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public interface IProdutosDao
    {
        void Incluir(Produtos p);
        void Excluir(int id);
        void Alterar(Produtos p);
        IEnumerable<Produtos> Listar();
    }
}
