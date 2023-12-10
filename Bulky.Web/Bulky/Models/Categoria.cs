using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Categoria")]
    public string Nome { get; set; }
    [DisplayName("Ordem de Exibição")]
    public int OrdemExibicao { get; set; }
}
