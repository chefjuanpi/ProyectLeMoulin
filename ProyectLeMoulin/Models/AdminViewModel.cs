using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
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

    public class NouvellesViewModel
    {
        public string NouvelleId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Titre trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titre")]
        public string Nouvelletitre { get; set; }

        [StringLength(300, ErrorMessage = "Nom d'image trop long, max. 300 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Image Principal")]
        public string NouvellePhotoPrincipal { get; set; }

        [Required]
        [StringLength(4000, ErrorMessage = "Nouvelle trop long, max. 4000 charactéres")]  // valeur a confirmer
        [DataType(DataType.Html)]
        [Display(Name = "Text")]
        public string NouvelleText { get; set; }

        [Required]
        [Display(Name = "Publier la notice  ou ")]
        public bool NouvellePublier { get; set; }

   

   }
}