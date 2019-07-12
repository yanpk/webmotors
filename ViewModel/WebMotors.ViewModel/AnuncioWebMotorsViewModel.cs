using System;
using System.ComponentModel.DataAnnotations;

namespace WebMotors.ViewModel
{
    public partial class AnuncioWebMotorsViewModel
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(45, ErrorMessage = "Campo {0} deve conter até 45 caracteres.")]
        [Display(Name = "marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(45, ErrorMessage = "Campo {0} deve conter até 45 caracteres.")]
        [Display(Name = "modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(45, ErrorMessage = "Campo {0} deve conter até 45 caracteres.")]
        [Display(Name = "versao")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(1000, ErrorMessage = "Campo {0} deve conter até 1000 caracteres.")]
        [Display(Name = "observacao")]
        public string Observacao { get; set; }

    }
}
