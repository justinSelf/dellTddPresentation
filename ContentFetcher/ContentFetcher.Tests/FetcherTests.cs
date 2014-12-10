using NUnit.Framework;
using Rhino.Mocks;

namespace ContentFetcher.Tests
{
    [TestFixture]
    public class FetcherTests
    {

        [Test]
        public void CallingFetchShouldCallTheProxyOnce()
        {
            //Arrange
            var proxyMock = MockRepository.GenerateStrictMock<IServiceProxy>();

            proxyMock.Expect(mock => mock.GetContent()).Return("").Repeat.Once();

            var fetcher = new Fetcher(proxyMock);

            //Act
            fetcher.Fetch();
            fetcher.Fetch();

            //Assert
            proxyMock.VerifyAllExpectations();
        }
    }
}