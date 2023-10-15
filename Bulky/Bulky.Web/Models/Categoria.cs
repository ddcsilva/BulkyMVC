using System.ComponentModel.DataAnnotations;

namespace Bulky.Web.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public int OrdemExibicao { get; set; }
    }
}