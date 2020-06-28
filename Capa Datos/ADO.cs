using System;

// Para contactar con la WEB API
using System.Net.Http;
using System.Net.Http.Headers;

namespace CapaDatos
{
   public abstract class ADO
    {
        
        protected HttpClient client = new HttpClient();

        public ADO()
        {
            client.BaseAddress = new Uri("http://localhost:60000/");           
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(10);
        }
    }
}
