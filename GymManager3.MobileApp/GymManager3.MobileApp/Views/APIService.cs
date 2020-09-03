using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using GymManager3.Model;
using Xamarin.Forms;

namespace GymManager3.MobileApp
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        private string _route = null;
        private string _apiURL = "http://localhost:56230/api";
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiURL}/{_route}";
            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            
            try
            {
                 var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                return result;
            }
            catch(FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    //MessageBox.Show("Niste authentificirani");
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                }
                throw;

            }
            
            
        }

        public async Task<T> Get<T>()
        {
            var result = await $"{_apiURL}/{_route}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }
        //public async Task<T> GetByUsername<T>(object search)
        //{
        //    var url = $"{_apiURL}/{_route}";
        //    if (search != null)
        //    {
        //        url += "?";
        //        url += await search.ToQueryString();
        //    }

        //    try
        //    {
        //        var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        //        return result;
        //    }
        //    catch (FlurlHttpException ex)
        //    {
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
        //        {
        //            //MessageBox.Show("Niste authentificirani");
        //            await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
        //        }
        //        throw;

        //    }
        //    //var url = $"{_apiURL}/{_route}/{username}";
        //    //return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        //}

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiURL}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiURL}/{_route}";
            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{_apiURL}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
        //public async Task<dynamic> Auth(/*object username, object pass, object ulogaId*/)
        //{
        //    var url = $"{_apiURL}/{_route}";

        //    return await url.GetJsonAsync<dynamic>();
        //}
        public async Task<T> Auth<T>(object username, object pass)
        {
            var url = $"{_apiURL}/{_route}/{username},{pass}";

            return await url.GetJsonAsync<dynamic>();
        }
        //public async Task<T> AuthTrener<T>(object username, object pass)
        //{
        //    var url = $"{_apiURL}/{_route}/{username},{pass}";

        //    return await url.GetJsonAsync<dynamic>();
        //}
    }
}

