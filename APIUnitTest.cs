using System;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace GeminiApiAutomation
{



    [TestFixture]
    public class UnitTest1
    {
        private Random random = new Random();

        [Test]
        public void GetUrl()
        {
            var client = new RestClient("https://api.gemini.com");
            var request = new RestRequest("/v1/order/new", Method.GET);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var result = output["nonce"];

            //verify key and value in dictionary
            Assert.That(result, Is.EqualTo("payload_nonce"), "Not Authenticated");

        }
        [Test]
        public void PostNewLimitOrderPayload()
        {
            var client = new RestClient("https://api.gemini.com");
            var request = new RestRequest("/v1/order/new", Method.POST);
            int payload_nonce = random.Next(1000);

            request.AddJsonBody(new
            {
                request = "/v1/order/new",
                nonce = payload_nonce,
                client_order_id = "123abc",
                symbol = "btcusd",
                amount = "10",
                price = "5500.00",
                side = "buy",
                type = "exchange limit"
            });

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["side"];

            Assert.That(result, Is.EqualTo("buy"), "Sell");
            Assert.AreEqual(200, response.StatusCode);


        }
        [Test]
        public void PostInvalidEndPoint()
        {
            var client = new RestClient("https://api.gemini.com");
            var request = new RestRequest("/v3/orders/neW", Method.POST);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output;

            Assert.AreEqual(400, response.StatusCode);

        }
    }
}

       


        //private async Task <IRestResponse<T>> ExecuteAsyncRequest<T>(RestClient client, IRestRequest request) where T:class, new()
        //{
        //    var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
        //    client.ExecuteAsync<T>(request, restResponse =>
        //    {
        //       if (restResponse.ErrorException != null)
        //       {
        //           const string message = "Error retriving response.";
        //           throw new ApplicationException(message, restResponse.ErrorException);
        //       }
        //       taskCompletionSource.SetResult(restResponse);

        //   });
        //    return await taskCompletionSource.Task;
        //}


//    }
//}
