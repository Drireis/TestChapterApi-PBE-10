using ExoApi.Controllers;
using ExoApi.Interfaces;
using ExoApi.Models;
using ExoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestExoApi.Controller
{
    public class TestLoginController
    {
        public void TestLoginControllerUsuarioInvalido() 
        {
            //Arrange
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadoLogin = new LoginViewModel();

            dadoLogin.Email = "email@email.com.br";
            dadoLogin.Senha = "1234";

            var controller = new LoginController(fakeRepository.Object);
            //Act

            var resultado = controller.Login(dadoLogin);
            
            //Assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

    }
}
