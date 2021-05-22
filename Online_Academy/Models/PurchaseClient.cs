using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Online_Academy.Models
{
    public class PurchaseClient
    {
        private string Base_URL = "https://localhost:44329/api/";
        public List<sp_Purchase_Result> GetPurchase(int idUser)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Purchase" + idUser).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<sp_Purchase_Result>>().Result;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}