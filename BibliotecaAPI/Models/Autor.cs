using BibliotecaAPI.Models;
using System.Text.Json.Serialization;

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; }

    
    public List<Livro> Livros { get; set; } = new List<Livro>();
}
