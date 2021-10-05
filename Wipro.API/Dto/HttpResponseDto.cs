using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wipro.Dtos
{
    public class HttpResponseDto
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public HttpResponseDto(int statusCode)
        {
            StatusCode = statusCode;
            SetStatus();
        }

        public HttpResponseDto SetMessage(string message)
        {
            Message = message;
            return this;
        }

        public HttpResponseDto Send(object data)
        {
            Data = data;
            return this;
        }

        private void SetStatus()
        {
            switch (StatusCode)
            {
                case 200:
                    Status = "OK";
                    break;
                case 201:
                    Status = "CREATED";
                    break;
                case 400:
                    Status = "BADREQUEST";
                    break;
                case 404:
                    Status = "NOTFOUND";
                    break;
                default:
                    Status = "";
                    break;
            }
        }
    }
}