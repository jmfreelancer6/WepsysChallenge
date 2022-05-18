using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Models
{
    public class PersonDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nombre obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido obligatorio")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Email obligatorio")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
    }
}
