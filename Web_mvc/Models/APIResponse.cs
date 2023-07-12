﻿using System.Net;

namespace Web_mvc.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<String> ErrorMessage { get; set; }
        public Object Result { get; set; }
    }
}
