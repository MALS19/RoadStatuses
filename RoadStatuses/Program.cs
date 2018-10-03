using System;
using RoadStatusServices;
using System.Reflection;
using ClassLibrary2.RoadStatusRepository;
using Ninject;

namespace RoadStatuses
{
   public class Program
    {
        private const int ErrorSuccess = 0;
        private const int ErrorInvalidFunction = 1;


        static void Main()
        {

            var objServices = CallRoadStatusServices();


            var input = Convert.ToString(Console.ReadLine());
            var output = objServices.GetStatusOfRoad(input);
            if (output.Result != null)
            {
                Console.WriteLine("The status of the " + output.Result[0].DisplayName + " is as follows");
                Console.WriteLine($"Road Status is {output.Result[0].StatusSeverity}");
                Console.WriteLine($"Road Status Description is {output.Result[0].StatusSeverityDescription}");
                Console.WriteLine("echo $lastexitcode " + ErrorSuccess);
                Environment.ExitCode = ErrorSuccess;
            }
            else
            {
                Console.WriteLine($" {input} is not a valid road ");
                Console.WriteLine("echo $lastexitcode " + ErrorInvalidFunction);
                Environment.ExitCode = ErrorInvalidFunction;
            }
            Console.ReadKey();
        }


        #region exit the application 
        //static int Main()
        //{

        //    var objServices = CallRoadStatusServices();


        //    var input = Convert.ToString(Console.ReadLine());
        //    var output = objServices.GetStatusOfRoad(input);
        //    if (output.Result != null)
        //    {
        //        Console.WriteLine("The status of the " + output.Result[0].DisplayName + " is as follows");
        //        Console.WriteLine($"Road Status is {output.Result[0].StatusSeverity}");
        //        Console.WriteLine($"Road Status Description is {output.Result[0].StatusSeverityDescription}");
        //        Console.WriteLine("echo $lastexitcode " + ERROR_SUCCESS);
        //       return Environment.ExitCode = ERROR_SUCCESS;
        //    }
        //    else
        //    {
        //        Console.WriteLine($" {input} is not a valid road ");
        //        Console.WriteLine("echo $lastexitcode " + ERROR_INVALID_FUNCTION);
        //       return  Environment.ExitCode = ERROR_INVALID_FUNCTION;
        //    }
        //    Console.ReadKey();
        //}
       #endregion

        private static GetRoadStatusServices CallRoadStatusServices()
        {
            StandardKernel _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            IGetResponseFromWebApi _getRoadStatus = _kernel.Get<IGetResponseFromWebApi>();
            GetRoadStatusServices _objServices = new GetRoadStatusServices(_getRoadStatus);
            return _objServices;
        }
    }
}
