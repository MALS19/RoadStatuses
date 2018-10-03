using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Ninject;
using ServicesProject;

namespace ClassLibrary2.RoadStatusRepository
{
  public  class GetResponseFromWebWebApi:IGetResponseFromWebApi
    {
        
        public async Task<List<RoadCorridor>> GetStatusOfRoadFromApi(string nameOfRoad)
        {
            var id = nameOfRoad.Trim();
            try
            {
                var httpClient = new HttpClient();
                string appId = ConfigurationManager.AppSettings.Get("AppId");
                string appKey = ConfigurationManager.AppSettings.Get("Appkey");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(appId, appKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.BaseAddress = new Uri("https://api.tfl.gov.uk");
                var url = "Road/" + id;
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var strResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<RoadCorridor>>(strResult);

                }
                else
                {
                    var statusCode = response.StatusCode;
                   Console.WriteLine($" {statusCode} ErrorAPI has occured ");

                }
               
            }
            catch (HttpResponseException ex)
            {
              throw new HttpRequestException("ErrorAPI occured calling third party web api", ex);
              
            }

            return null;
        }
    }
}
