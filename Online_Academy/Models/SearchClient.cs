using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Online_Academy.Models
{
    public class SearchClient
    {

        private string Base_URL = "https://localhost:44329/api/";

        public List<Course> SearchbyName(string text)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Search/" + text).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<Course>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}