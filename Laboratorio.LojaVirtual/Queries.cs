using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public static class Queries
    {
        public static void ManyToMany()
        {
            using (var readContexto = new LojaContext())
            {
                var promocoes = readContexto
                    .Promocoes
                    .Include(promocao => promocao.Produtos)
                    .ThenInclude(promocaoProduto => promocaoProduto.Produto)
                    .ToList();

                foreach (var promocao in promocoes)
                {
                    foreach (var produto in promocao.Produtos)
                    {
                        Console.WriteLine(produto.Produto);
                    }
                }
            }
        }

        public static void OneToOne()
        {
            using (var contexto = new LojaContext())
            {
                var clientes = contexto
                    .Clientes
                    .Include(cliente => cliente.EnderecoEntrega)
                    .ToList();

                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"Cliente: {cliente.Nome}, Logradouro: {cliente.EnderecoEntrega.Logradouro}");
                }
            }
        }

        public static void OneToMany()
        {
            using (var contexto = new LojaContext())
            {
                var produtos = contexto
                    .Produtos
                    .Include(produto => produto.Compras)
                    .ToList();

                foreach (var produto in produtos)
                {
                    foreach (var compra in produto.Compras)
                    {
                        Console.WriteLine($"Produto: {produto.Nome}, Quantidade da Compra: {compra.Quantidade}, Valor da Compra: {compra.Preco}");
                    }
                }
            }
        }

        public static void ExplicitLoad()
        {
            using (var contexto = new LojaContext())
            {
                var produto = contexto
                    .Produtos
                    .Where(x => x.Id == 4002)
                    .FirstOrDefault();

                if (produto == null)
                    return;

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 2)
                    .Load();

                foreach (var c in produto.Compras)
                {
                    Console.WriteLine($"Compra: quantidade = {c.Quantidade}, valor = {c.Preco}");
                }
            }
        }

        public static void UsingLinq()
        {
            using (var contexto = new LojaContext())
            {
                var produtos = (from p in contexto.Produtos
                                join c in contexto.Compras on p.Id equals c.ProdutoId
                                where
                                    c.Preco > 2
                                select p).ToList();

                foreach (var p in produtos)
                {
                    Console.WriteLine(p.Nome);
                }
            }
        }
    }
}
