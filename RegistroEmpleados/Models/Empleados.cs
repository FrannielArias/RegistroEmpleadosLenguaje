using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroEmpleados.Models;

public class Empleados {

    [Key]
    public int EmpleadoId { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]
    [Required(ErrorMessage = "Nombre Obligatorio")]

    public string? Nombre { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]
    [Required(ErrorMessage = "Apellidos Obligatorios")]

    public string? Apellidos { get; set; }

    [ForeignKey("NominaId")]
    public int NominaId { get; set; }

    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$")]
    [Required(ErrorMessage = "Cédula Obligatoria")]

    public string? Cedula { get; set; }

    [Required(ErrorMessage = "Dirección Obligatorio")]

    public string? Direccion { get; set; }

    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
    [Required(ErrorMessage = "Teléfono Obligatorio")]
    
    public string? Telefono { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]
    [Required(ErrorMessage = "Profesión Obligatorio")]

    public string? Profesion { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]
    [Required(ErrorMessage = "Departamento Obligatorio")]

    public string? Departamento { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]
    [Required(ErrorMessage = "Puesto de Trabajo Obligatorio")]

    public string? PuestoTrabajo { get; set; }

    //instancia de la clase Nomina
    public Nominas? Nomina { get; set; }
}