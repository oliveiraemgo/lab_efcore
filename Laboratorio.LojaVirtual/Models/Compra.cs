namespace Laboratorio.LojaVirtual
{
    public class Compra
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; internal set; }
        public Produtos Produto { get; internal set; }
        public double Preco { get; internal set; }
    }
}