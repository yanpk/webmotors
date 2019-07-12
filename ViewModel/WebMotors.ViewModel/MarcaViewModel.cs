using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebMotors.ViewModel
{
    public class MarcaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(45, ErrorMessage = "Campo {0} deve conter até 45 caracteres.")]
        [Display(Name = "marca")]
        public string Name { get; set; }
    }
}
