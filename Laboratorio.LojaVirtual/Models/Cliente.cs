namespace Laboratorio.LojaVirtual
{
    public class Cliente
    {
        public Cliente()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco EnderecoEntrega { get; set; }
    }
}