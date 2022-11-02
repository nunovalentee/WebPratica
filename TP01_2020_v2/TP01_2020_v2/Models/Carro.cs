using System.ComponentModel.DataAnnotations;

namespace TP01_2020_v2.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required!")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Range(2000,2022, ErrorMessage ="{0} de matricula tem de ser superior a {1}!")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [RegularExpression(@"([^\\s]+(\\.(?i)(jpe?g|png|gif|bmp))$)", ErrorMessage = "Only jpg images!")]
        public string Foto { get; set; }
        
        [Required(ErrorMessage = "This field is required!")]
        public Boolean Vendido { get; set; } = false;
    }
}
