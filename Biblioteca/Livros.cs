using System.ComponentModel.DataAnnotations;

namespace Biblioteca
{
    public class Livros
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Titulo { get; set; }

        [StringLength(100)]
        public string? Subtitulo { get; set; }

        [StringLength(500)]
        public string? Resumo { get; set; }

        [Required]
        public int QuantidadeDePaginas { get; set; }

        [Required]
        public string? DataDaPublicacao { get; set; }

        [Required]
        [StringLength(150)]
        public string? Editora { get; set; }

        [StringLength(2)]
        public string? Edicao { get; set; }

        [Required]
        [StringLength(50)]
        public string? Autores { get; set; }
    }
}
