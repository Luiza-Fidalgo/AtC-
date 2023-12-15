using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace At_C__2023.Models
{
    public class Flor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório. Por favor, informe seu nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Especie é obrigatória. Por favor, informe sua especie.")]
        public string Especie { get; set; }

        [Required(ErrorMessage = "A Quantidade é obrigatória. Por favor, informe a quantidade.")]
        public int Quantidade { get; set; }

        [DisplayName("Disponivel no Estoque?")]
        public string Disponivel { get; set; }

    }
}
