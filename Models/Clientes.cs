using System.ComponentModel.DataAnnotations;

namespace Prio.Models;

public class Clientes
{
    [Key]
    public int ClienteID { get; set; }
    [Required(ErrorMessage = "El campo {0} es Requerido")]
    public string? Nombre { get; set; }
    public int Telefono { get; set; }
    [Required(ErrorMessage = "El campo {0} es Requerido")]
    public int Celular { get; set; }
    [Required(ErrorMessage = "El campo {0} es Requerido")]
    public int RNC { get; set; }
    public string? Email { get; set; }
    public string? Dirección { get; set; }
}
