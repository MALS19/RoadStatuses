using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using ClassLibrary2.Entity;
using ClassLibrary2.RoadStatusRepository;
using Moq;
using RoadStatusServices;
using ServicesProject;
using Xunit;
using Assert = Xunit.Assert;

namespace ClassLibrary1
{
    public class RoadTest
    {

        [Fact]
        public async Task WhenValidRoadIDIsPassedThan_ItShouldDisplayCorrectID()
        {
            var id = "A2";
            var repo = new Mock<IGetResponseFromWebApi>();
            repo.Setup(b => b.GetStatusOfRoadFromApi(It.IsAny<string>())).Returns(Task.FromResult(GetResponse()));

            var service = new GetRoadStatusServices(repo.Object);

            var result = await service.GetStatusOfRoad(id);



            Assert.Equal("a2", result[0].Id);

        }




        [Fact]
        public async Task WhenValidRoadIDIsPassedThan_ItShouldDisplayCorrectName()
        {
            var id = "A2";
            var repo = new Mock<IGetResponseFromWebApi>();
            repo.Setup(b => b.GetStatusOfRoadFromApi(It.IsAny<string>())).Returns(Task.FromResult(GetResponse()));

            var service = new GetRoadStatusServices(repo.Object);

            var result = await service.GetStatusOfRoad(id);


           
            Assert.Equal("A2", result[0].DisplayName);
           
        }



        [Fact]
        public async Task WhenValidRoadIDIsPassedThan_ItShouldDisplayCorrectStatusSeverity()
        {
            var id = "A2";
            var repo = new Mock<IGetResponseFromWebApi>();
            repo.Setup(b => b.GetStatusOfRoadFromApi(It.IsAny<string>())).Returns(Task.FromResult(GetResponse()));

            var service = new GetRoadStatusServices(repo.Object);

            var result = await service.GetStatusOfRoad(id);


          
            Assert.Equal("Good", result[0].StatusSeverity);
          
        }



        [Fact]
        public async Task WhenValidRoadIDIsPassedThan_ItShouldDisplayCorrectStatusSeverityDescription()
        {
            var id = "A2";
            var repo = new Mock<IGetResponseFromWebApi>();
            repo.Setup(b => b.GetStatusOfRoadFromApi(It.IsAny<string>())).Returns(Task.FromResult(GetResponse()));

            var service = new GetRoadStatusServices(repo.Object);

            var result = await service.GetStatusOfRoad(id);


            
            Assert.Equal("No Exceptional Delays", result[0].StatusSeverityDescription);
        }

        [Fact]
        public async Task
            WhenInValidRoadIDIsPassedThan_ResultWillBeNull()
        {
            var repo = new Mock<IGetResponseFromWebApi>();
            var id = "A233";
            repo.Setup(b => b.GetStatusOfRoadFromApi(It.IsAny<string>())).Returns(Task.FromResult(GetInvalidResponse()));

            var service = new GetRoadStatusServices(repo.Object);

            var result = await service.GetStatusOfRoad(id);

            Assert.Null(result);
          
        }

       





        private List<RoadCorridor> GetResponse()
        {
            var response = new RoadCorridor()
            {
                Id = "a2",
                DisplayName = "A2",
                StatusSeverity = "Good",
               StatusSeverityDescription = "No Exceptional Delays"

            };
            return new List<RoadCorridor> {response};
        }

        private List<RoadCorridor> GetInvalidResponse()
        {
            var response = new RoadCorridor()
            {
                Id = "A233",
                ErrorApis = new List<ErrorAPI>()
                {
                    new ErrorAPI()
                    {
                        ExceptionType = "EntityNotFoundException",
                        HttpStatusCode = 404,
                        HttpStatus = "NotFound",
                        Message = "The following road id is not recognised: A233"
                    }
                }
            };
            return new List<RoadCorridor> { response };

        }

    }
}
