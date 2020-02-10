using Abp.Threading;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleSDK.Common
{
    public class ApiCaller : IDisposable
    {
        #region Variables
        private HttpClient Client { get; set; }
        private HttpResponseMessage Response { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor: create HttpClient with json data 
        /// </summary>
        /// <param name="uri"> Uri for web api</param>
        public ApiCaller()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"] ?? throw new ArgumentNullException("Base Url Not Found!"));
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Other
        public void Dispose()
        {
            try
            {
                if (Response != null)
                    Response.Dispose();
                if (Client != null)
                    Client.Dispose();
            }
            finally
            {
                Client = null;
                Response = null;
            }
        }
        #endregion

        #region Async Methods

        /// <summary>
        /// Call HttpGet method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl"> Url for get method in api {api/[controllerName]/[methodName]}.
        /// you can add parameters in url like : (.. method?name=value)</param>
        /// <returns> Result of execute get method in api</returns>
        public async Task<T> GetAsync<T>(string action, string controller)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.GetAsync(methodUrl);
            if (Response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await Response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new HttpRequestException($"error: while executing http request, " +
                    $"status code is {Response.StatusCode}");
            }
        }

        /// <summary>
        /// Call HttpPost method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for post method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute post method in api [if there is result] </returns>
        public async Task<T> PostAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PostAsync(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }

        /// <summary>
        /// Call HttpPut method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for put method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute put method in api [if there is result] </returns>
        public async Task<T> PutAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PutAsync(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {

            }

        }

        /// <summary>
        /// Call HttpDelete method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl"> Url for delete method in api {api/[controllerName]/[methodName]}.
        /// you can add parameters in url like : (.. method?name=value)</param>
        /// <returns> Result of execute delete method in api [if there is result]</returns>
        public async Task<T> DeleteAsync<T>(string action, string controller, Guid id)
        {
            var methodUrl = string.Format("{0}/{1}/{2}", controller, action, id);
            Response = await Client.DeleteAsync(methodUrl);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }

        ///// <summary>
        /// Call HttpPost method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for post method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute post method in api [if there is result] </returns>
        public async Task<T> PostAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PostAsJsonAsync<R>(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {

            }
        }

        /// <summary>
        /// Call HttpPut method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for put method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute put method in api [if there is result] </returns>
        public async Task<T> PutAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PutAsync(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }

        /// <summary>
        /// Call HttpDelete method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl"> Url for delete method in api {api/[controllerName]/[methodName]}.
        /// you can add parameters in url like : (.. method?name=value)</param>
        /// <returns> Result of execute delete method in api [if there is result]</returns>
        public async Task<T> DeleteAsync<T>(string action, string controller, Guid id)
        {
            var methodUrl = string.Format("{0}/{1}/{2}", controller, action, id);
            Response = await Client.DeleteAsync(methodUrl);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }
        ///// <summary>
        /// Call HttpPost method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for post method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute post method in api [if there is result] </returns>
        public async Task<T> PostAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PostAsJsonAsync<R>(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {

            }
        }

        /// <summary>
        /// Call HttpPut method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for put method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute put method in api [if there is result] </returns>
        public async Task<T> PutAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PutAsync(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }

        /// <summary>
        /// Call HttpDelete method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl"> Url for delete method in api {api/[controllerName]/[methodName]}.
        /// you can add parameters in url like : (.. method?name=value)</param>
        /// <returns> Result of execute delete method in api [if there is result]</returns>
        public async Task<T> DeleteAsync<T>(string action, string controller, Guid id)
        {
            var methodUrl = string.Format("{0}/{1}/{2}", controller, action, id);
            Response = await Client.DeleteAsync(methodUrl);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }
        ///// <summary>
        /// Call HttpPost method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for post method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute post method in api [if there is result] </returns>
        public async Task<T> PostAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PostAsJsonAsync<R>(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
        }

        /// <summary>
        /// Call HttpPut method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl">Url for put method in api {api/[controllerName]/[methodName]}.</param>
        /// <param name="data"> data to pass throw post method </param>
        /// <returns> Result of execute put method in api [if there is result] </returns>
        public async Task<T> PutAsync<T, R>(string action, string controller, R data)
        {
            var methodUrl = string.Format("{0}/{1}", controller, action);
            Response = await Client.PutAsync(methodUrl, data);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }

        /// <summary>
        /// Call HttpDelete method in web api [Asynchronous]
        /// </summary>
        /// <param name="methodUrl"> Url for delete method in api {api/[controllerName]/[methodName]}.
        /// you can add parameters in url like : (.. method?name=value)</param>
        /// <returns> Result of execute delete method in api [if there is result]</returns>
        public async Task<T> DeleteAsync<T>(string action, string controller, Guid id)
        {
            var methodUrl = string.Format("{0}/{1}/{2}", controller, action, id);
            Response = await Client.DeleteAsync(methodUrl);
            if (Response.IsSuccessStatusCode)
            {
                return await Response.Content.ReadAsAsync<T>();
            }
            else
            {
            }
        }
        #endregion

    }
}
