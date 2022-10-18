using Microsoft.AspNetCore.Mvc;

namespace BikeListApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] //everyone public method is an action
    public class BikeListController : ControllerBase
    {   
    

        private static readonly string[] Bikes =  //array for list of bike Manufacturers
        {
        "Specialized Bicycle Components", "Trek Bikes", "Santa Cruz", "Giant Bicycles", "Yeti Cycles", "Ibis Cycles", "Pivot Cycles", "Evil Bike Co.", "Cannondale", "Salsa Cycles" , "Kona", "Co-op Cycles", "YT Industries", "Marin"
    };

        private readonly ILogger<BikeListController> _logger;

        public BikeListController(ILogger<BikeListController> logger)
        {
            _logger = logger;
        }

        private Random gen = new Random();
        DateTime RandomDay() //helped function used to generate random dates
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        [HttpGet]
        public IEnumerable<BikeListing> GetBikeList()
        {
            return Enumerable.Range(1, 5).Select(index => new BikeListing
            {
                //Date = DateTime.Now.AddDays(index),
                Date = RandomDay(),
                LowEndPrice = Random.Shared.Next(400, 800),
                Bikes = Bikes[Random.Shared.Next(Bikes.Length)]

            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<string> GetAttributes() 
        {
            return Bikes;
        }
    }
}