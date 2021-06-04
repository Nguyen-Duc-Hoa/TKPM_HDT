using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Online_Academy.Models
{
    public class BookdetailClient
    {
        private string Base_URL = "https://localhost:44329/api/";

        //get Cart by User
        public List<Cart> getCartbyUser(int idUser)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Bookdetails/Cart/" + idUser).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<Cart>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }


        public IEnumerable<Bookdetail> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Bookdetails").Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<IEnumerable<Bookdetail>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Bookdetail> findByStudent(int id_student)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Bookdetails/" + id_student).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<IEnumerable<Bookdetail>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Bookdetail find(int id_student, int id_course)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Bookdetails?id_student=" + id_student + "&id_course=" + id_course).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Bookdetail>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(Bookdetail book)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Bookdetails", book).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(int id_student, int id_course)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Bookdetails?id_student=" + id_student + "&id_course=" + id_course).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}