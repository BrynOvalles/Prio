﻿using System.ComponentModel.DataAnnotations;

namespace Prio.Models;

public class Sistema
{
    [Key]
    public int SistemaId { get; set; }
    [Required(ErrorMessage = "Campo {0} es requerido")]
    public string? Nombre { get; set; }
}