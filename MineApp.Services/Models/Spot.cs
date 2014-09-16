using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineApp.Models
{
    public class Spot
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Resource { get; set; }


        public Spot()
        {

        }
    }
}
