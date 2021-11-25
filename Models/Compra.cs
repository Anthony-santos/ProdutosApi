using System;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Models
{
    public class Compra
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int Produto_Id { set; get; }
        public int Qtde_Comprada { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public Cartao Cartao { set; get; }
    }
}