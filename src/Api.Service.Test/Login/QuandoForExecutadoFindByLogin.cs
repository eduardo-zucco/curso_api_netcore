using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método FindByLogin.")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
            var email = Faker.Internet.Email();
            var objectRetorno = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "Usuário logado com sucesso"
            };
            
        }

        
    }
}