using System.ComponentModel.DataAnnotations;

namespace Projeto_Milionario.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} deve estar entre {2} e {1}!")]
        [Display(Name = "Nome do Curso")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} deve estar entre {2} e {1}!")]
        [Display(Name = "Escola ou Instituição")]
        public string Escola { get; set; }

        [Display(Name = "Estado")]
        public Boolean State { get; set; } = false;

        public List<Utilizador>? Utilizadores { get; set; } 
    }
}
