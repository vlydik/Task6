using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task6.MiddleWares
{
    public class LoggingMiddleWare
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request != null)
            {
                string path = context.Request.Path;
                string queryString = context.Request?.QueryString.ToString();
                string method = context.Request.Method.ToString();
                string bodyParameters = String.Empty;

                using(StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyParameters = await reader.ReadToEndAsync();
                }
            }
            else
            {
                string error = $"Error caught: Path: {context.Request.Path} queryString: {context.Request?.QueryString.ToString()} method:{context.Request.Method.ToString()} time: {DateTime.Now.ToLongTimeString()}";
                Logs.WriteLog(error);
            }
        }
    }
}
