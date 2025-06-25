using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private CepsController _controller;
        [Fact(DisplayName = "É Possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
               new CepDtoCreateResult
               {
                   Id = Guid.NewGuid(),
                   Cep = "123.456",
                   CreatedAt = DateTime.UtcNow
               }
           );

            _controller = new CepsController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();

            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Cep = "123.456",
                Numero = "12"
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);

            

        }
    }
}