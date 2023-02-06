using ExoApi.Controllers;
using ExoApi.Interfaces;
using ExoApi.Models;
using ExoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXUnitExoApi.Controller
{
    public class TestLoginController
    {
        [Fact]
        public void LoginControllerUsuarioInvalido()
        {
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadosLogin = new LoginViewModel();

            dadosLogin.Email = "testemail@email.com";
            dadosLogin.Senha = "1234";

            var controller = new LoginController(fakeRepository.Object);

            var resultado = controller.Login(dadosLogin);

            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }
        [Fact]
        public void LoginControllerToken()
        {
            Usuario usuarioRetorno = new Usuario();
            usuarioRetorno.Email = "email@email.com";
            usuarioRetorno.Senha = "1234";
            usuarioRetorno.Tipo = "1";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetorno);
            string issuerValidacao = "ExoApi";

            LoginViewModel dadosLogin = new LoginViewModel();
            dadosLogin.Email = "email@email.com";
            dadosLogin.Senha = "1234";

            var controller = new LoginController(fakeRepository.Object);

            ObjectResult resultado= (ObjectResult)controller.Login(dadosLogin);

            string token = resultado.Value.ToString().Split("")[3];

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJwt = jwtHandler.ReadJwtToken(token);

            Assert.Equal(issuerValidacao, tokenJwt.Issuer);
        }
    }
}
