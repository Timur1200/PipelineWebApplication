using System.ComponentModel.DataAnnotations;

namespace PipelineWebApplication.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите Логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Pass { get; set; }
    }
}
