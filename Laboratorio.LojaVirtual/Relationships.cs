using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public static class Relationships
    {
        /// <summary>
        /// One To Many
        /// 1 produto está em N compras
        /// </summary>
        public static void OneToMany()
        {
            // 1 produto
            var pao = new Produtos();
            pao.Nome = "Pão Francês";
            pao.PrecoUnitario = 0.40;
            pao.Unidade = "UN";
            pao.Categoria = "Padaria";

            // N compras
            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = pao;
            compra.Preco = pao.PrecoUnitario * compra.Quantidade;

            var contexto = new LojaContext();
            contexto.Compras.Add(compra);
            contexto.SaveChanges();
        }

        /// <summary>
        /// Many To Many
        /// 1 promoção tem N produtos
        /// 1 produto está em N promoções
        /// </summary>
        public static void ManyToMany()
        {
            // 1 promoção
            var promocao = new Promocao();
            promocao.Descricao = "Páscoa Feliz";
            promocao.DataInicio = DateTime.Now;
            promocao.DataTermino = DateTime.Now.AddMonths(3);
            
            // N produtos
            promocao.AddProduto(new Produtos
            {
                Nome = "Suco de Laranja",
                Categoria = "Bebidas",
                PrecoUnitario = 8.79,
                Unidade = "Litros"
            });
            promocao.AddProduto(new Produtos
            {
                Nome = "Café",
                Categoria = "Bebidas",
                PrecoUnitario = 12.45,
                Unidade = "Gramas"
            });
            promocao.AddProduto(new Produtos
            {
                Nome = "Macarrão",
                Categoria = "Alimentos",
                PrecoUnitario = 4.23,
                Unidade = "Gramas"
            });

            var contexto = new LojaContext();
            contexto.Promocoes.Add(promocao);
            contexto.SaveChanges();
        }
    }
}
