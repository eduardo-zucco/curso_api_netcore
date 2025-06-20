using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome do Município é Campo Obrigatório")]
        [StringLength(60, ErrorMessage = "Nome de Município deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Codigo do IBGE inválido")]
        public int CodIBGE { get; set; }
        [Required(ErrorMessage = "Código de UF é Campo Obrigatório")]
        public Guid UfId { get; set; }
        
    }
}