using System.ComponentModel.DataAnnotations;

namespace Siparis.Web.UI.Models.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Email Adresinizi Giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler Aynı Olmalı")]
        public string PasswordCompare { get; set; }
    }
}
