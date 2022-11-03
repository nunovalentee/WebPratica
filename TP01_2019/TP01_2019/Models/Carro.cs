using System.ComponentModel.DataAnnotations;

namespace TP01_2019.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Equipa { get; set; }
    }
}
