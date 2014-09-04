using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nom de Rôle")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Courriel")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Prenom trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        [Display(Name = "Cellulaire")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Nom trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        public bool susp { get; set; }
    }

    public class AccueilViewModel
    {
        [Required]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Contenu de page d'accueil")]
        public string Contenu { get; set; }

        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Code du facebook")]
        public string Gauche { get; set; }
    }

    public class ContactViewModel
    {
        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Code du map :")]
        public string map { get; set; }


        [StringLength(150, ErrorMessage = "Adresse trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Addresse :")]
        public string addresse { get; set; }


        [StringLength(150, ErrorMessage = "Nom de Ville trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Ville :")]
        public string ville { get; set; }


        [StringLength(100, ErrorMessage = "error dans le nom de province")]
        [DataType(DataType.Text)]
        [Display(Name = "Province :")]
        public string prov { get; set; }

        [StringLength(6, ErrorMessage = "error dans le format")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{ L9L9L9L9}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, HtmlEncode = true)]
        [RegularExpression("([A-Z]\\d){3}", ErrorMessage="le code postal doit correspopnde a G7Y6U8")]
        [Display(Name = "Code Postal :")]
        public string codPos { get; set; }

        [RegularExpression(@"^(\([0-9]{3}\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$",
    ErrorMessage = "Svp éntres le numéero dans le bon format: (123) 123-1234")]
        [Phone]
        [DisplayFormat(DataFormatString = "{(999) 999-9999}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull= true, HtmlEncode= true)]
        [Display(Name = "Téléphone")]
        public string Phone { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Courriel")]
        public string Email { get; set; }
    }

    public class PagesViewModel
    {
        public string PId { get; set; }
        
        [Required]
        [StringLength(15, ErrorMessage = "Titre trop long, max. 15 charactéres")]
        public string MenuName { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Titre trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titre du Page :")]
        public string Titre { get; set; }

        [Required]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Contenu")]
        public string Contenu { get; set; }

        [Required]
        [Display(Name = "Publier cette page ")]
        public bool Publier { get; set; }

        [Required]
        [Display(Name = "Dans le menu principal  ou comme sous-menu de :")]
        public bool Principal { get; set; }

        public int menuParent { get; set; }

        [Display(Name = "Partager sur Facebbok ")]
        public bool fb { get; set; }
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
        [AllowHtml]
        [Display(Name = "Lieu :")]
        public string Lieu { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Adresse trop long, max. 300 charactéres")]
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
        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Text")]
        public string Contenu { get; set; }

        [Required]
        [Display(Name = "Metre publique l'evenement ")]
        public bool Publier { get; set; }

        [Display(Name = "Partager sur Facebbok ")]
        public bool fb { get; set; }
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
        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Contenu")]
        public string NouvelleText { get; set; }

        [Required]
        [Display(Name = "Publier cette nouvelle ")]
        public bool Publier { get; set; }

        [Display(Name = "Partager sur Facebbok ")]
        public bool fb { get; set; }
    }

    public class PachatsViewModel
    {
        [Required]
        [StringLength(150, ErrorMessage = "Titre trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titre du page :")]
        public string Titre { get; set; }

        [Required]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Presentation du Groupre de achats")]
        public string Contenu { get; set; }

        [Display(Name = "Partager sur Facebbok ")]
        public bool fb { get; set; }
    }
}