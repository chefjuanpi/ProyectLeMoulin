
using System.Net.Mail;
namespace IdentitySample.Models
{
    public class MailModel
    {
        public string from { get; set; }
        public string to { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        
    }
}