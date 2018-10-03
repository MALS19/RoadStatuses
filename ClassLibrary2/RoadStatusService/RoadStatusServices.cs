using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ClassLibrary2.RoadStatusRepository;
using Newtonsoft.Json;
using Ninject;
using ServicesProject;

namespace RoadStatusServices
{
    public class GetRoadStatusServices:IGetRoadStatusServices
    {
        private readonly IGetResponseFromWebApi _repo;


        [Inject]
        public GetRoadStatusServices(IGetResponseFromWebApi repo)
        {
            _repo = repo;
        }


        public async Task<List<RoadCorridor>> GetStatusOfRoad(string nameOfRoad)

        {
        
            return await _repo.GetStatusOfRoadFromApi(nameOfRoad);
      }

      
    }
}
