using EVoucher_CMS_Client.Models.RequestModels;
using EVoucher_CMS_Client.Models.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher_CMS_Client.APIRepo
{
    public class APIRequest
    {
        //public static string BaseUrl = "https://localhost:44346/"; //IIS Express LocalHost
        public static string BaseUrl = "http://localhost:8005/"; //IIS Window Server

        public static async Task<LoginResponse> PostLogin(string url, LoginRequest entity)
        {
            url = BaseUrl + url;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var content = new StringContent(JsonConvert.SerializeObject(entity), UTF8Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<LoginResponse>(objsJsonString);
                            return jsonContent;
                        }
                        else
                        {
                            return default(LoginResponse);
                        }
                    }
                }
            }
        }

        public static async Task<SubmitEVoucherResponse> PostEV(string url, SubmitEVoucherRequest entity, string tokenString)
        {
            url = BaseUrl + url;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var content = new StringContent(JsonConvert.SerializeObject(entity), UTF8Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<SubmitEVoucherResponse>(objsJsonString);
                            return jsonContent;
                        }
                        else
                        {
                            return default(SubmitEVoucherResponse);
                        }
                    }
                }
            }
        }

    }

    public class APIRequest<T>
    {
        //public static string BaseUrl = "https://localhost:44346/"; //IIS Express LocalHost
        public static string BaseUrl = "http://localhost:8005/"; //IIS Window Server

        public static async Task<T> Get(string url, string tokenString)
        {
            url = BaseUrl + url;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await client.GetAsync(string.Format(url)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);

                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
            catch
            {
                return default(T);
            }
        }

    }
}
