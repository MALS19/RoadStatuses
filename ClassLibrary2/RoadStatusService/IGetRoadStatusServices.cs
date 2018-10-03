using ServicesProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatusServices
{
   public interface IGetRoadStatusServices
    {
        Task<List<RoadCorridor>> GetStatusOfRoad(string nameOfRoad);
    }
}
