using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.RoadStatusRepository;
using RoadStatusServices;

namespace RoadStatuses
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IGetRoadStatusServices>().To<GetRoadStatusServices>();
            Bind<IGetResponseFromWebApi>().To<GetResponseFromWebWebApi>();
        }
    }
}
