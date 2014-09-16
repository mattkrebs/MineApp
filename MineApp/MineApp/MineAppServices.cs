using System;
using Xamarin.Geolocation;
using System.Threading.Tasks;
using System.Collections.Generic;
using MineApp.ViewModels;
using MineApp.Models;


namespace MineApp
{
    public class MineAppServices
    {
        public MineAppServices()
        {
        }

        private List<SpotViewModel> _nearSpots;

        public List<SpotViewModel> NearSpots
        {
            get { return _nearSpots; }
            set {
                if (_nearSpots == null)
                    _nearSpots = new List<SpotViewModel>();

                _nearSpots = value; }
        }
        
		
        private static MineAppServices _current; 

        public static MineAppServices Current
        {
            get
            {
                if (_current == null)
                    _current = new MineAppServices();

                return _current;
            }
        }

        private Position _currentPosition;
		public Position CurrentPosition {
			get{
				return _currentPosition;
			}
			set{
				_currentPosition = value;
				UpdateSpots(value);
			}
		} 
		public async Task UpdateSpots(Position newPosition){
			await Task.Run(() => {
                NearSpots = FindMiningSpots(newPosition);
			});
		}
        public List<SpotViewModel> FindMiningSpots(Position position)
        {
			List<SpotViewModel> spots = new List<SpotViewModel>();
            foreach (var item in GetSpots())
            {
				var spotVM = new SpotViewModel(item, position.Latitude, position.Longitude);
				if (spotVM.Distance < 0.25)
                {
					spots.Add(spotVM);
                }
            }
			return spots;
        }


        public List<Spot> GetSpots()
        {

            var spots = new List<Spot>();

            spots.Add(new Spot() { Name = "RBA", Description = "Digital Technology Company", Latitude = 44.9695310, Longitude = -93.5175940, Resource = "Gold" });
            spots.Add(new Spot() { Name = "Krebs House", Description = "Maker of this App", Latitude = 45.0693650, Longitude = -93.4384470, Resource = "Platinum" });
            return spots;
        }




    }
}

