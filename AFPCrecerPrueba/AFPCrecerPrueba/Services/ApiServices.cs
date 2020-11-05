using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AFPCrecerPruebaAPI.Services
{
    public class ApiServices
    {
        public async Task<Response> GetUser(string urlBase, string prefix, string controller, string email)
        {
            try
            {
                var getUserRequest = new GetUserRequest
                {
                    Email = email
                };

                var request = JsonConvert.SerializeObject(getUserRequest);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}/{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer
                    };
                }

                var user = JsonConvert.DeserializeObject<Afiliado>(answer);

                return new Response
                {
                    IsSuccess = true,
                    Result = user
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }
    }
}