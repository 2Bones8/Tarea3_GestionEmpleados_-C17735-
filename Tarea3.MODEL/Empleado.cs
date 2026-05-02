using System.ComponentModel.DataAnnotations;

namespace Tarea3.MODEL
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(80)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El departamento es requerido")]
        public string Departamento { get; set; } = string.Empty;

        [Required]
        [Range(400000, 10000000, ErrorMessage = "El salario debe estar entre 400,000 y 10,000,000")]
        public decimal Salario { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }

        // Propiedad calculada requerida
        public string NombreCompleto => $"{Nombre} {Apellidos}";
    }
}