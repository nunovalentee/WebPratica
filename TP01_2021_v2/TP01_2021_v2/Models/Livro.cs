using System.ComponentModel.DataAnnotations;

namespace TP01_2021_v2.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [StringLength(100, ErrorMessage = "{0} lenght must be between {2} and {1}!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [StringLength(150, MinimumLength = 4, ErrorMessage ="{0} lenght must be between {2} and {1}!")]
        public string Autores { get; set; }


        [Required(ErrorMessage = "This field is required!")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [RegularExpression(@"^[0-9]{3}-[0-9]-[0-9]{2}-[0-9]{6}-[0-9]$", ErrorMessage ="Formato inválido!")]
        public string ISBN { get; set; }

        // formato .jpg
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Formato inválido!")]
        public string? Capa { get; set; }

        // formato .jpg
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Formato inválido!")]
        public string? Contracapa { get; set; }
    }
}
