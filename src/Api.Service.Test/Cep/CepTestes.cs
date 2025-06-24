using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Cep
{
    public class CepTestes
    {
        public Guid IdCep { get; set; }
        public string CepOriginal { get; set; }
        public string CepAlterado { get; set; }
        public string LogradouroOriginal { get; set; }
        public string LogradouroAlterado { get; set; }
        public string NumeroOriginal { get; set; }
        public string NumeroAlterado { get; set; }
        public Guid IdMunicipio { get; set; }
        
        public List<CepDto> listaDto = new List<CepDto>();
        public CepDto cepDto{ get; set; }
        public CepDtoCreate cepDtoCreate;
        public CepDtoCreateResult cepDtoCreateResult;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoUpdateResult cepDtoUpdateResult;


        public CepTestes()
        {
            IdCep = Guid.NewGuid();
            CepOriginal = Faker.RandomNumber.Next(10000, 999999).ToString();
            CepAlterado = Faker.RandomNumber.Next(10000, 999999).ToString();
            LogradouroOriginal = Faker.Address.StreetAddress();
            LogradouroAlterado = Faker.Address.StreetAddress();
            NumeroOriginal = Faker.RandomNumber.Next(1, 2000).ToString();
            NumeroAlterado = Faker.RandomNumber.Next(1, 2000).ToString();
            IdMunicipio = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CepDto
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(10000, 999999).ToString(),
                    Logradouro = Faker.Address.StreetAddress(),
                    Numero = Faker.RandomNumber.Next(1, 2000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = IdMunicipio,
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaDto.Add(dto);
            }

            cepDto = new CepDto
            {
                Id = IdCep,
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = IdMunicipio,
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }

                }
            };

            cepDtoCreate = new CepDtoCreate
            {
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio
            };
            cepDtoCreateResult = new CepDtoCreateResult
            {
                Id = IdCep,
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                CreatedAt = DateTime.UtcNow
            };
            cepDtoUpdate = new CepDtoUpdate
            {
                Id = IdCep,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio
            };
            cepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = IdCep,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow
            };




        }
    }
}