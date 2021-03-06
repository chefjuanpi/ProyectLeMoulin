﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace IdentitySample.Controllers
{
    class Panier
    {
        

        public string ProductName { get; set; }

        public int Qantity { get; set; }

        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public int SupplierId { get; set; }



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
}
