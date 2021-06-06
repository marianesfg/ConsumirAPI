using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsumirAPI
{
    class Program
    {
        static void Main()
        {          
            string URL = "https://gorest.co.in/public-api/users/";
            string parametros = "123/posts";

            List<Post> lista = new List<Post>();
            lista.Add(new Post("tit1", "bod1"));
            lista.Add(new Post("tit2", "body2"));
            lista.Add(new Post("tit3", "body3"));

            string DATA;

            foreach (Post l in lista)
            {
                //"{\r\n                    \"title\": \"Component 2\",    \r\n                    \"body\": \"TP\"}" 
                //DATA = @"{
                //    ""title"": ""Component 2"",    
                //    ""body"": ""TP""}";

                //"{\r\n                    \"title\": tit1,    \r\n                    \"body\": bod1}"
                DATA = @"{
                    ""title"": """ + l.Title + @""",    
                    ""body"": """ + l.Body + @"""}";

                string bearerToken = string.Format("token");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage messge = client.PostAsync(URL + parametros, content).Result;
                string description = string.Empty;
                if (messge.IsSuccessStatusCode)
                {
                    string result = messge.Content.ReadAsStringAsync().Result;
                    description = result;
                }
            }
        }    
    }
}
