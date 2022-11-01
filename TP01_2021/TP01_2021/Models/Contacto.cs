using System.ComponentModel.DataAnnotations;

namespace TP01_2021.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="{0} tem que estar entre {2} e {1}")]
        [RegularExpression(@"[a-zA-Z\d]{3,}", ErrorMessage = "Invalido")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Boolean Amigo { get; set; } = false;
    }
}
