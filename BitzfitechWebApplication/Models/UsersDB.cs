using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BitzfitechWebApplication.Models {
    public class UsersDB {
        
        public int Id { get; set; }
        
        [StringLength(50), Required]
        [RegularExpression(@"[A-Za-z\s]{1,20}", ErrorMessage = "Invalid/Too Many characters")]
        public string Name { get; set; }
        
        [StringLength(30), Required]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true), Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Display(Name = "Twitter Handle"), StringLength(20)]
        [RegularExpression(@"^@(\w){4,20}$", ErrorMessage = "Invalid Username Format")]
        public string TwitterHandle { get; set; }
        
        [Display(Name = "Favourite Netflix show"), StringLength(50)]
        public string FavNetflix { get; set; }

        [Display(Name = "Number of cats")]
        public int NumCats { get; set; }
        
        [Display(Name = "Share data with 3rd party "), Required]
        public bool DataShare { get; set; }
    }

    public class UserDBContext : DbContext {

        public DbSet<UsersDB> Users { get; set; }
    }

    public class NetflixShow {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}