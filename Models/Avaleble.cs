using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Example.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using test_4.Controllers;
using test_4.Models;

namespace Example.Models
{
    public class Avaleble
    {
        public Avaleble() {}
        
        public Avaleble(DateTime date, string user)
        {
            Date = date;
            User = user;
        }


        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Birthdate")]
        public DateTime Date { get; set; }
        
        // Foreign to the relevant ApplicationUser
    
     
        public string User { get; set; }
    }
}
