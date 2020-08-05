using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;

namespace CatalcaliWebAppV2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Tarayıcıyı Hatırla?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Eposta")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "Ad")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Adres")]
        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} en az {2} karater uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password", ErrorMessage = "Şifreler birbiri ile uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} en az {2} karater uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler birbiri ile uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
    }

    public class ChangeUserInformationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }
    }

    public class ChangeUserAddressViewModel
    {
        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }
    }
}
