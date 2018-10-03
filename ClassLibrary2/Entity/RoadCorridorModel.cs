using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Entity;

namespace ServicesProject
{
   public class RoadCorridor
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public string StatusSeverityDescription { get; set; }

        public string StatusSeverity { get; set; }

        public List<ErrorAPI> ErrorApis { get; set; }


    }

   
}
