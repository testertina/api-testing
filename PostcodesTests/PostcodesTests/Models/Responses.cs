using System.Net;

namespace PostcodesTests.Models
{
    public class Responses<T> where T : class
    {
        public T Content { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
