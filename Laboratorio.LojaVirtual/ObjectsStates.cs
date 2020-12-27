using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public class ObjectsStates
    {
        /// <summary>
        /// Teste dos estados dos objetos
        ///     unchanged    >> sem alterações
        ///     modified     >> modificado
        ///     added        >> adicionado
        ///     deleted      >> removido
        ///     detached     >> desanexado
        /// </summary>
        public static void Executar()
        {
            // desativa o change tracker
            //var contexto = new LojaContext();
            //contexto.ChangeTracker.AutoDetectChangesEnabled = false;

            // Detecta todas as mudanças dos objetos caso o AutoDetectChagesEnabled seja false
            //contexto.ChangeTracker.DetectChanges();

            Added();
            Modified();
            Deleted();

            Detached();
            Unchanged();
        }

        /// <summary>
        /// Unchaged State.
        /// </summary>
        private static void Unchanged()
        {
            var contexto = new LojaContext();
            var produtos = contexto.Produtos.ToList();
            WriteStates(contexto.ChangeTracker.Entries());
        }

        /// <summary>
        /// Modified State.
        /// </summary>
        private static void Modified()
        {
            var contexto = new LojaContext();
            var produtos = contexto.Produtos.ToList();
            var produto = produtos.FirstOrDefault();
            if (produto != null)
                produto.Nome = "TV";
            WriteStates(contexto.ChangeTracker.Entries());
        }

        /// <summary>
        /// Added State.
        /// </summary>
        private static void Added()
        {
            var contexto = new LojaContext();

            var novoProduto = new Produtos
            {
                Nome = "Mouse"
            };

            contexto.Produtos.Add(novoProduto);

            WriteStates(contexto.ChangeTracker.Entries());

            contexto.SaveChanges();

            WriteStates(contexto.ChangeTracker.Entries());
        }

        /// <summary>
        /// Deleted State.
        /// </summary>
        private static void Deleted()
        {
            var contexto = new LojaContext();
            var produto = contexto.Produtos.FirstOrDefault();
            if (produto != null)
            {
                contexto.Produtos.Remove(produto);
                WriteStates(contexto.ChangeTracker.Entries());
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Detached State.
        /// </summary>
        private static void Detached()
        {
            var contexto = new LojaContext();
            var produto = new Produtos();
            Console.WriteLine(contexto.Entry(produto));
        }

        private static void WriteStates(IEnumerable<EntityEntry> entries)
        {
            var contexto = new LojaContext();

            foreach (var item in entries)
            {
                Console.WriteLine(item);
            }
        }
    }
}
