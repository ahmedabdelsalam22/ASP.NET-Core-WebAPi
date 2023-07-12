using System.Net;

namespace WebAPi.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<String> ErrorMessage { get; set; }
        public Object Result { get; set; }
    }
}
