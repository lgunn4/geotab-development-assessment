using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace JokeGeneratorTests.Utils
{
    public static class HttpClientFactoryMocker
    {
        public static IHttpClientFactory Mock(string jsonResult) 
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync", 
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
             
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResult),
                })
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            
            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(t => t.CreateClient(It.IsAny<string>())).Returns(httpClient);

            return mockFactory.Object;
        }
    }
}