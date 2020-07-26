using RestSharp;
using System.Web;
using PostcodesTests.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace PostcodesTests.Setup
{
    public class SendRequest
    {

        private HttpRequest _httpRequest;

        public SendRequest(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public IRestResponse SendBulkLookupRequest(List<string> postcodes)
        {
            var request = new HttpSetup().SetMethod(Method.POST).SetResource("postcodes/").AddJsonContent(postcodes);
            var response = request.Execute();
            return response;

        }
    }
}
