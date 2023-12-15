using System.ComponentModel.DataAnnotations;

namespace At_C__2023.Models
{
    public class Vaso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório. Por favor, informe seu tipo.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O Tamanho é obrigatório. Por favor, informe seu tamanho.")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "A Cor é obrigatório. Por favor, informe seu cor.")]
        public string Cor { get; set; }
    }
}
