using RestSharp;
using System;
using System.Collections.Generic;

namespace PostcodesTests.Setup
{
    public class HttpSetup
    {
        private RestClient _restClient;
        private RestRequest _restRequest;

        public HttpSetup()
        {
            _restRequest = new RestRequest();

        }

        public HttpSetup SetMethod(Method method)
        {
            _restRequest.Method = method;
            return this;
        }

        public HttpSetup SetResource(string apiEndpoint)
        {
            _restRequest.Resource = apiEndpoint;
            return this;
        }

        public HttpSetup AddValue(Parameter value)
        {
            _restRequest.AddParameter(value);
            return this;
        }

        public HttpSetup AddParameter(string name, object value)
        {
            _restRequest.AddParameter(name, value);
            return this;
        }

        public HttpSetup AddParameters(IDictionary<string, object> parameters)
        {
            foreach (var item in parameters)
            {
                _restRequest.AddParameter(item.Key, item.Value);
            }
            return this;
        }

        public HttpSetup AddHeaders(IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _restRequest.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }
            return this;
        }

        public HttpSetup AddJsonContent(object data)
        {
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddJsonBody(data);
            return this;
        }

        //public IRestResponse Execute()
        //{
        //    try
        //    {
        //        IRestResponse response = _restClient.Execute(_restRequest);
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception thrown of type:" + e.Source);
        //        throw;
        //    }
        //}

        public IRestResponse Execute()
        {
            try
            {
                _restClient = new RestClient("http://postcodes.io/");
                var response = _restClient.Execute(_restRequest);
                return response;
            }

            catch(Exception e )
            {
                Console.WriteLine("Exception thrown of type:" + e.Source);
                throw;
            }

        }
    }
}
