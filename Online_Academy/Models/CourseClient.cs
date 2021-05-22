using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Online_Academy.Models
{
    public class CourseClient
    {
        private string Base_URL = "https://localhost:44329/api/";

        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Courses").Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<IEnumerable<Course>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Course> GetTeacherCourses(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("TeacherCourses/"+id).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<IEnumerable<Course>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Course> GetCoursesByState(bool state)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("CoursesByState/" + state).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<IEnumerable<Course>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Course> GetCoursesByStateSave(int id,bool statesave)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("CoursesByStateSave?id=" + id+"&statesave="+statesave).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<IEnumerable<Course>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<sp_Couse_User_Result> GetCourseByUser(int idUser)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Course_User/"+ idUser).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<List<sp_Couse_User_Result>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Course GetCourse(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respone = client.GetAsync("Courses/" + id).Result;
                if (respone.IsSuccessStatusCode)
                    return respone.Content.ReadAsAsync<Course>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool UpdateCourse(Course course)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Courses/" + course.id, course).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool AddCourse(Course course)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Courses", course).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCourse(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Courses/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveLike(int idStudent, int idCourse)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Courses/RemoveLike/" + idStudent + "/" + idCourse).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}