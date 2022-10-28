using MartianExplorer.Models.Entitites;
using System;

namespace MartianExplorer.Services
{
    public interface ILocationService
    {
        void Move(Explorer explorer, LocationRequest locationRequest);
    }
    public class LocationService : ILocationService
    {
        private readonly MartianSurface _martianSurface;

        public LocationService(MartianSurface marsField)
        {
            _martianSurface = marsField;
        }


        void ILocationService.Move(Explorer explorer, LocationRequest locationRequest)
        {
            
        }
    }
}
