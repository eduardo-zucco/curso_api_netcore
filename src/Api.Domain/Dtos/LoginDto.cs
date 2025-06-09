using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Dtos
{
    public class LoginDto
    {

        [Required(ErrorMessage = "E-mail é um campo obrigatório para o Login!")]
        [EmailAddress(ErrorMessage = "Formato de E-mail inválido!")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres!")]
        public string Email { get; set; }  
    }
}