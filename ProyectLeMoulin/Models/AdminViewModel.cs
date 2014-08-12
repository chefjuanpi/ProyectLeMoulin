using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System;

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
        public string PId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Titre trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titre du Notice :")]
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
        [Display(Name = "Publier cette nouvelle ")]
        public bool Publier { get; set; }
   }

    public class PagesViewModel
    {
        public string PId { get; set; }
        
        [Required]
        public string MenuName { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Titre trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titre du Notice :")]
        public string Titre { get; set; }

        [Required]
        [StringLength(4000, ErrorMessage = "Nouvelle trop long, max. 4000 charactéres")]  // valeur a confirmer
        [DataType(DataType.Html)]
        [Display(Name = "Text")]
        public string Contenu { get; set; }

        [Required]
        [Display(Name = "Publier cette page ")]
        public bool Publier { get; set; }

        [Required]
        [Display(Name = "Dans le menu principal  ou comme sous-menu de :")]
        public bool Principal { get; set; }

        public int menuParent { get; set; }
    }

    public class EvenementsViewModel
    {
        public string PId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Titre trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titre du Évenement :")]
        public string Titre { get; set; }

        [StringLength(300, ErrorMessage = "Nom d'image trop long, max. 300 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Image Principal")]
        public string PhotoPrincipal { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Nom du lieu trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Lieu :")]
        public string Lieu { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Adresse trop long, max. 300 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Adresse :")]
        public string Adresse { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HourStart { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HourEnd { get; set; }

        [Required]
        [StringLength(4000, ErrorMessage = "Nouvelle trop long, max. 4000 charactéres")]  // valeur a confirmer
        [DataType(DataType.Html)]
        [Display(Name = "Text")]
        public string Contenu { get; set; }

        [Required]
        [Display(Name = "Metre publique l'evenement ")]
        public bool Publier { get; set; }
    }
}