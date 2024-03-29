using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Models
{
    public class Cartao
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Titular { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [CreditCard(ErrorMessage = "Cartão de crédito inválido")]
        public string Numero { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Data_Expiracao { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Bandeira { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Cvv { set; get; }
    }
}