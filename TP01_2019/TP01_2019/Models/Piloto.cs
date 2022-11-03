using System.ComponentModel.DataAnnotations;

namespace TP01_2019.Models
{
    public class Piloto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório!")]
        public string Nome { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "O campo {0} tem que ser superior a {1}.")]
        public int? Pontos { get; set; } = 0;

        public int? CarroId { get; set; }

        public Carro? Carro { get; set; }
    }
}
