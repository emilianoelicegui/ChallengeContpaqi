using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contpaqi.Data.DataTransferObjects
{
    public class EmployeeDto
    {
        public int? Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "El apellido materno es requerido")]
        public string MiddleName { get; set; } = null!;
        [Required(ErrorMessage = "La edad es requerida")]
        public int Age { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "El género es requerido")]
        public string Gender { get; set; } = null!;
        [Required(ErrorMessage = "El estado civil es requerido")]
        public string CivilStatus { get; set; } = null!;
        [Required(ErrorMessage = "El rfc es requerido")]
        public string Rfc { get; set; } = null!;
        [Required(ErrorMessage = "La dirección es requerida")]
        public string Address { get; set; } = null!;
        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "El número de teléfono es requerido")]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "La posición es requerida")]
        public string Position { get; set; } = null!;
        public DateTime? EndDate { get; set; }
    }
}
