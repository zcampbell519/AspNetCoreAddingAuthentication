using System.ComponentModel.DataAnnotations;

namespace WishList.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(100),MinLength(8), DataType(DataType.Password)]
        public string Password{get;set;}
        [Required,DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}