using System.ComponentModel.DataAnnotations;

namespace Appointment.DTOs
{
    public class LoginInputDto
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="مقدار دهی این فیلد الزامی است")]
        public string UserName { get; set; }=string.Empty;

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "مقدار دهی این فیلد الزامی است")]
        public string Password { get; set; } = string.Empty;
    }
}
