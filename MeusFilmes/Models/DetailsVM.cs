namespace MeusFilmes.Models;

public class DetailsVM
{
    public Serie Anterior { get; set; }
    public Serie Atual { get; set; }
    public Serie Proximo { get; set; }
    public List<Genero> Generos { get; set; }
}