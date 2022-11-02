using System.ComponentModel.DataAnnotations;

namespace TP01_2018.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required!")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.DateTime)]
        public DateTime DataRegisto { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int NivelCliente { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [RegularExpression(@"[9][0-9]{8}")]
        public string Telefone { get; set; }
    }
}
