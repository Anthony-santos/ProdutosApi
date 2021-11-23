using System;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Valor_Unitario { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio", AllowEmptyStrings = false)]
        public int Qtde_Estoque { set; get; }

        public DateTime Ultima_Venda { set; get; }

        public decimal Valor_Ultima_venda { set; get; }
    }
}