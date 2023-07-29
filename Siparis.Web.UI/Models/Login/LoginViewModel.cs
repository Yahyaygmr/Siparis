using System.ComponentModel.DataAnnotations;

namespace Siparis.Web.UI.Models.Login
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

    }
}
