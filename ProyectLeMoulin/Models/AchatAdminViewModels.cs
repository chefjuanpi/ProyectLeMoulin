using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EpicerieModel.Models
{
    /// <summary>
    /// Modèle des données contenu dans Supplier
    /// </summary>
    public class SupplierViewModel
    {

        public string SupplierId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Nom trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom du fournisseur :")]
        public string SupplierName { get; set; }

        [StringLength(100, ErrorMessage = "Nom du contact trop long, max. 100 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Nom du contact :")]
        public string SupplierContactName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Numéro trop long")]  // valeur a confirmer
        [DataType(DataType.Text)]
        [Display(Name = "# Téléphone :")]
        public string SupplierPhone { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Numéro trop long")]  // valeur a confirmer
        [DataType(DataType.Text)]
        [Display(Name = "# Fax :")]
        public string SupplierFax { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Courriel trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Courriel :")]
        public string SupplierMail { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Adresse trop longue, max. 200 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Adresse :")]
        public string SupplierAdress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nom de ville trop long, max. 100 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Ville :")]
        public string SupplierCity { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Code trop long")]  // valeur a confirmer
        [DataType(DataType.Text)]
        [Display(Name = "Code Postal :")]
        public string SupplierPostalCode { get; set; }
    }

    /// <summary>
    /// Modèle des données contenu dans Week
    /// </summary>
    public class WeekViewModel
    {
        public DateTime DateSemaine { get; set; }

        public int ProductId { get; set; }

        public int SupplierId { get; set; }

        [Required]
        [Range(1,1000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Cout :")]
        public decimal UnitPrice { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Nombre entier uniquement")]
        [Required]
        [StringLength(3, ErrorMessage = " Quantité trop élevé")]
        [Display(Name = "Quantité minimum :")]
        public int Quantity { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 caractères")]
        [DataType(DataType.Text)]
        [Display(Name = "Format :")]
        public string Format { get; set; }
    }
}