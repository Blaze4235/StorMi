using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StorMi.Interfaces;

namespace StorMi.Services
{
    public class ApiInvoker : IApiInvoker
    {
        //private readonly List<string> _apiRequests;

        //public ApiInvoker(List<string> apiRequests)
        //{
        //    _apiRequests = apiRequests;
        //}

        //public void AddApiRequest(string apiRequest)
        //{
        //    _apiRequests.Add(apiRequest);
        //}

        //public void RemodeApiRequest(string apiRequest)
        //{
        //    _apiRequests.Remove(apiRequest);
        //}

        //public async Task<IDictionary<string, dynamic>> InvokerAll()
        //{
        //    try
        //    {
        //        Dictionary<string, dynamic> dictRes = new Dictionary<string, dynamic>();

        //        foreach (var apiRequest in _apiRequests)
        //        {
        //            using (var httpClient = new HttpClient())
        //            {
        //                using (var response = await httpClient.GetAsync(apiRequest))
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    var res = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(apiResponse);
        //                    dictRes.Add(apiRequest, res);
        //                }
        //            }
        //        }

        //        return dictRes;
        //    }
        //    catch (Exception exc)
        //    {
        //        // Log
        //    }

        //    throw new NotSupportedException();
        //}
        public async Task<dynamic> Invoke(string apiRequest)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiRequest))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var res = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(apiResponse);
                    return res;
                }
            }
        }
    }
}