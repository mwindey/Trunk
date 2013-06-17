using System.ComponentModel.DataAnnotations;

namespace Definco.Models
{
   public class ContactModel{

           [Required]
           [StringLength(256, ErrorMessage = "Het {0} moet ten minste {2} karakters lang zijn.", MinimumLength = 1)]
           [Display(Name = "Waarmee kan ik u van dienst zijn?")]
           public string Vraag { get; set; }

           [Required]
           [Display(Name = "Hoe kan ik u bereiken? (gsm/email)")]
           public string ContactMiddel { get; set; }



           public ContactModel()
           {
             
           }
      
   
   }
}