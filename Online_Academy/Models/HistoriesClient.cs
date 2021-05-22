using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Online_Academy.Models
{
    public class HistoriesClient
    {

        private string Base_URL = "https://localhost:44329/api/";
        public List<sp_Course_bought_Result> GetAllCourse(int idUser)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Histories" + idUser).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<sp_Course_bought_Result>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool AddHistory(History history)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Histories", history).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                return false;
            }
        }
    }
}