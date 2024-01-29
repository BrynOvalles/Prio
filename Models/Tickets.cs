using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Prio.Models;

public class Tickets
{
    [Key]
    public int TicketID { get; set; }
    [Required(ErrorMessage = "Ingresar Fecha.")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Today;
    [ForeignKey("Clientes")]
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public int ClienteID { get; set; }
    [ForeignKey("Sistema")]
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public int SistemaID { get; set; }
    [ForeignKey("Prioridades")]
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public int PrioridadID { get; set; }
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public string? Solicitante { get; set; }
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public string? Asunto { get; set; }
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public string? Descripcion { get; set; }
}