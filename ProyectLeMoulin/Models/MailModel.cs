
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
namespace IdentitySample.Models
{
    public class MailModel
    {
        public string from { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Courriel")]
        public string to { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Sujet trop long, max. 150 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Sujet")]
        public string Subject { get; set; }

        [Required]
        [StringLength(3000, ErrorMessage = "le message est de max. 3000 charactéres")]
        [DataType(DataType.Text)]
        [Display(Name = "Contenu")]
        public string Body { get; set; }

        public string adresse { get; set; }
        
    }
}