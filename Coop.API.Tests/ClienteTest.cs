using Coop.Domain.Cliente.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Coop.API.Tests
{
    public class ClienteTest
    {
        [Fact]
        public async Task ClienteCrearTest()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();



            var result = await client.PostAsJsonAsync("/clientes", new ClienteRequestModel()
            {
                Nombres = "Jose Lema",
                Direccion = "Otavalo sn y principal",
                Telefono = "098254785",
                Contrasena = "1245",
                Estado = true
            });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }


    }
}