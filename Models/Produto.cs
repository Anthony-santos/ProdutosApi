using System;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Model
{
    public class Produtos
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public bool Valo_Unitario { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int Qtde_Estoque { set; get; }

        public DateTime Ultima_Venda { set; get; }

        public decimal Valor_Ultima_venda { set; get; }
    }
}