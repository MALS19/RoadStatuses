using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesProject;

namespace ClassLibrary2.RoadStatusRepository
{
  public  interface IGetResponseFromWebApi
  {
      Task<List<RoadCorridor>> GetStatusOfRoadFromApi(string nameOfRoad);
  }
}
