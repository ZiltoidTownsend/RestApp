using LibraryMenu;
using Newtonsoft.Json;
using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestApp.Other
{
    public static class ConnectingToApi
    {
        static HttpClient client = new HttpClient();

        static async public Task<List<CategoryModel>> GetMenu(CookieContainer cookie)
        {

            // Update port # in the following line.
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookie;
            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("https://localhost:44339/api/Categories").Result;

                List<CategoryModel> dishes = new List<CategoryModel>();
                dishes = await response.Content.ReadAsAsync<List<CategoryModel>>();
                return dishes;
            }
        }

        static async public Task<OrderModel> GetIdOrder()
        {
            // Update port # in the following line.
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("https://localhost:44339/api/Orders").Result;

                OrderModel order = await response.Content.ReadAsAsync<OrderModel>();
                return order;
            }
        }

        static async public Task<UserModel> Login(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            var uri = new Uri("https://localhost:44339/api/Login");
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsync("https://localhost:44339/api/Login", data).Result;

                //IEnumerable<string> cookies = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
                var responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
                var result = await response.Content.ReadAsAsync<UserModel>();
                result.Cookies = cookies;

                return result;
            }
        }

        static async public Task<UserModel> Registration(UserModel user)
        {            
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (HttpClient client = new HttpClient(handler))
            {
                Uri uri = new Uri("https://localhost:44339/api/Registration");
                CookieContainer cookies = new CookieContainer();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("https://localhost:44339/api/Registration", data).Result;
                var responseCookies = cookies.GetCookies(uri).Cast<Cookie>();

                var result = await response.Content.ReadAsAsync<UserModel>();

                //handler.CookieContainer.GetCookies(uri);
                return result;
            }
        }
    }
}
