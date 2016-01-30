using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebApiClient.Tests.Integration
{
    [TestFixture]
    public class CanRetriveData
    {
        public class ShopDetails
        {
            public int Id { get; set; }
            public int DefaultPoints { get; set; }
            public double Distance { get; set; }
            public string HomeImageUrl { get; set; }
        }

        public class ShopDetailList : List<ShopDetails>
        {
        }

        [Test]
        public async Task GetData_Returns_Data()
        {
            var urlEndpoint =
                @"http://localhost:50549/api/closebyshops2?latitude=51.514318&longitude=-0.087319&sortBy=Distance&shopTypeId=0&searchText=";

            var apiClient = new WebApiRequest<ShopDetailList>(urlEndpoint);

            var results = await apiClient.GetDataAsync();

            Assert.IsTrue(results.Any());
        }
    }
}