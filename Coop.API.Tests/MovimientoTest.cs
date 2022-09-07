using Coop.Domain.Cliente.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Coop.API.Tests
{

    public class MovimientoTest
    {
        [Fact]
        public async Task ReporteTest()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var result = await client.GetAsync("/");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}