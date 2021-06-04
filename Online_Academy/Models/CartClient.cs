using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Online_Academy.Models
{
    public class CartClient
    {

        private string Base_URL = "https://localhost:44329/api/";

        //get Cart by User
        public List<sp_Cart_Result> getCartbyUser(int idUser)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Cart/" + idUser).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<sp_Cart_Result>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}