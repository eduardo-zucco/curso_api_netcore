using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoUpdate
    {
        [Required(ErrorMessage = "Id é Campo Obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "CEP é Campo Obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Logradouro é Campo Obrigatório")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        [Required(ErrorMessage = "Município é Campo Obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}