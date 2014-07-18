using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProyectLeMoulin.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Prenom trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Nom trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}