using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Online_Academy.Models
{
    public class LectureClient
    {
        private string Base_URL = "https://localhost:44329/api/";
        //using async
        //public async Task<IEnumerable<Lecture>> GetAllLectures()
        //{
        //    HttpClient client = new HttpClient();
        //    string path = "api/Lectures";
        //    IEnumerable<Lecture> data = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        data = await response.Content.ReadAsAsync<IEnumerable<Lecture>>();
        //    }
        //    return data;
        //}

        public List<Lecture> GetAllLectures()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Lectures").Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<Lecture>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<Lecture> GetLectureByCurriculum(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("GetLectureCurriculum/"+id).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<Lecture>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Lecture GetLecture(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Lectures/" + id).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<Lecture>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool UpdateLecture(Lecture lecture)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Lectures/" + lecture.id, lecture).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool AddLecture(Lecture lecture)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Lectures/", lecture).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteLecture(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync("Lectures/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}