using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Prio.Models;

public class Tickets
{
    [Key]
    public int TicketId { get; set; }
    [Required(ErrorMessage = "Ingresar Fecha.")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Now;
    [ForeignKey("Clientes")]
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public int ClienteId { get; set; }
    [ForeignKey("Sistema")]
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public int SistemaId { get; set; }
    [ForeignKey("Prioridades")]
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public int PrioridadId { get; set; }
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public string? Solicitante { get; set; }
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public string? Asunto { get; set; }
    [Required(ErrorMessage = " Campo {0} es requerido")]
    public string? Descripcion { get; set; }
}