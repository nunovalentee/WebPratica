using System.ComponentModel.DataAnnotations;

namespace TP01_2020.Models
{
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="{0} must be between {2} and {1}!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [RegularExpression(@"^Cliente|Restaurante$")]
        public string Tipo { get; set; }
    }
}
