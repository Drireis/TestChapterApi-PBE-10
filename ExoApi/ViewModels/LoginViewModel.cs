using System.ComponentModel.DataAnnotations;

namespace ExoApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O e-mail obrigatório!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrogatória!")]
        [StringLength(6)]
        public string? Senha { get; set; }
    }
}
