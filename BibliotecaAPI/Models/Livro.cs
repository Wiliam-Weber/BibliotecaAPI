﻿using System.Text.Json.Serialization;

namespace BibliotecaAPI.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
      


        public int AutorId { get; set; }
        public Autor? Autor { get; set; }

        public int EditoraId { get; set; }
        public Editora? Editora { get; set; }

        public List<Emprestimo>? Emprestimos { get; set; } // Tornar opcional
    }
}
