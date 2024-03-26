
namespace MeusFilmes.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<string> Genero { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }
    }
}