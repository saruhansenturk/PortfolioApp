using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PortfolioApp.TestApi
{
    public class ProgrammingLanguageTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProgrammingLanguageTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData(2, 7)]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(int pageNo, int pageSize)
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2ODY0Njc0NTUsImV4cCI6MTY4NjUyMTQ1NSwiaXNzIjoid3d3Lm15YXBpLmNvbSIsImF1ZCI6Ind3dy5iaWxtZW1uZS5jb20ifQ.2RmOkTrMVDbyid5u4PoVhNA88k9Tt8cnDt0RUvoq4ik");
            //client.BaseAddress = new Uri($"api/ProgrammingLanguages");

            var response = await client.GetAsync($"api/ProgrammingLanguages?pageNo={pageNo}&pageSize={pageSize}");


            //Assert
            response.EnsureSuccessStatusCode();
            var ss = await response.Content.ReadAsStringAsync();
            Assert.Equal("application/json; charset=utf-8",
                response?.Content?.Headers?.ContentType?.ToString());
        }


        //[Theory]
        ////[InlineData(2, 7)]
        //public async Task Post_EndpointsReturnSuccessAndCorrectContentType()
        //{
        //    var client = _factory.CreateClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2ODY0Njc0NTUsImV4cCI6MTY4NjUyMTQ1NSwiaXNzIjoid3d3Lm15YXBpLmNvbSIsImF1ZCI6Ind3dy5iaWxtZW1uZS5jb20ifQ.2RmOkTrMVDbyid5u4PoVhNA88k9Tt8cnDt0RUvoq4ik");
        //    //client.BaseAddress = new Uri($"api/ProgrammingLanguages");

        //    var response = await client.GetAsync($"");


        //    //Assert
        //    response.EnsureSuccessStatusCode();
        //    var ss = await response.Content.ReadAsStringAsync();
        //    Assert.Equal("application/json; charset=utf-8",
        //        response?.Content?.Headers?.ContentType?.ToString());
        //}

    }
}
