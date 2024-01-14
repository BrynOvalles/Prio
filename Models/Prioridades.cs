using System.ComponentModel.DataAnnotations;
using Prio.DAL;
using Prio.BLL;

namespace Prio.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadID { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public string? Descripción { get; set; }
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int DiasCompromiso { get; set; }
    }
}
