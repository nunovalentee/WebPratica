using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Projeto_Milionario.Models
{
    public class Utilizador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [RegularExpression(@"^[0-9]{5}", ErrorMessage ="Numero de 5 digitos!")]
        public int Numero { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage ="{0} deve estar entre {2} e {1}!")]
        [Display(Name ="Nome completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^.+\.([jJ][pP][gG])", ErrorMessage ="Formato inválido!")]
        public string? Foto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [RegularExpression(@"Aluno|Professor")]
        public string Cargo { get; set; }

        public int CursoId { get; set; }

        public Curso? Curso { get; set; }

    }
}
