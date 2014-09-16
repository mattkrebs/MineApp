using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Xamarin.Forms;
using MineApp.Services;
using MineApp.Models;

[assembly: Dependency(typeof(SpotRepository))]
namespace MineApp.Services
{
    public class SpotRepository : InMemoryRepository<Spot>, IRepository<Spot> 
    {
        public SpotRepository()
        {
            Add(new Spot() { Name = "RBA", Description = "Digital Technology Company", Latitude = 44.9695310, Longitude = -93.5175940, Resource = "Gold" });
            Add(new Spot() { Name = "Krebs House", Description = "Maker of this App", Latitude = 45.0693650, Longitude = -93.4384470, Resource = "Platinum" });
        }
    }
}
