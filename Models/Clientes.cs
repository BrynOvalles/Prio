using System.ComponentModel.DataAnnotations;

namespace Prio.Models;

public class Clientes
{
	[Key]
	public int ClienteId { get; set; }
	[Required(ErrorMessage = "El campo {0} es Requerido.")]
	public string? Nombre { get; set; }
	[Required(ErrorMessage = "El campo {0} es requerido.")]
	[RegularExpression("^[0-9]+$", ErrorMessage = "El Teléfono solo puede contener dígitos.")]
	[StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")]
	public string? Telefono { get; set; }
	[Required(ErrorMessage = "El campo {0} es requerido.")]
	[RegularExpression("^[0-9]+$", ErrorMessage = "El Celular solo puede contener dígitos.")]
	[StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")]
	public string? Celular { get; set; }
	[Required(ErrorMessage = "El campo {0} es Requerido.")]
	[RegularExpression("^[0-9]+$", ErrorMessage = "El RNC solo puede contener dígitos.")]
	[StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "La longitud debe ser de 9 dígitos")]
	public string? RNC { get; set; }
	[Required(ErrorMessage = "El campo {0} es Requerido.")]
	public string? Email { get; set; }
	[Required(ErrorMessage = "El campo {0} es Requerido.")]
	public string? Dirección { get; set; }
}