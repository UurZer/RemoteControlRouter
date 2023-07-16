using Rcr.Data.Entity;
using Rcr.Data.Repository;
using Rcr.Service.Abstract;
using Rcr.Utilities.Consts;
using Rcr.Utilities.Results;

namespace Rcr.Service.Concrete
{
    public class RouteService : IRouteService
    {
        private VehicleRepository _VehicleRepository = null;

        public VehicleRepository VehicleRepository
        {
            get
            {
                if (_VehicleRepository is null)
                    _VehicleRepository = new VehicleRepository();
                return _VehicleRepository;
            }
        }

        private RouteRepository _RouteRepository = null;

        public RouteRepository RouteRepository
        {
            get
            {
                if (_RouteRepository is null)
                    _RouteRepository = new RouteRepository();
                return _RouteRepository;
            }
        }

        public IDataResult<Coordinate> MoveVehicle(Guid vehicleId, string commands)
        {
            Coordinate coordinate = new Coordinate();
            VehicleRoute vehicleRoute = new VehicleRoute();

            Vehicle currentVehicle = VehicleRepository.GetVehicleById(vehicleId);
            if (currentVehicle is null)
            {
                return new ErrorDataResult<Coordinate>("Araç bulunamadı!");
            }

            foreach(char command in commands)
            {
                switch (command)
                {
                    case 'M':
                        vehicleRoute = GetCurrentLocation(currentVehicle.Id);
                        if (vehicleRoute.Direction == RouteConst.Routes.North)
                            vehicleRoute.Y++;
                        else if (vehicleRoute.Direction == RouteConst.Routes.West)
                            vehicleRoute.X--;
                        else if (vehicleRoute.Direction == RouteConst.Routes.East)
                            vehicleRoute.X++;
                        else
                            vehicleRoute.Y--;

                        LocationControl(vehicleRoute);
                        break;
                    case 'L':
                        vehicleRoute = GetCurrentLocation(currentVehicle.Id);
                        
                        if (vehicleRoute.Direction == RouteConst.Routes.North)
                            vehicleRoute.Direction = RouteConst.Routes.West;
                        else if (vehicleRoute.Direction == RouteConst.Routes.West)
                            vehicleRoute.Direction = RouteConst.Routes.South;
                        else if (vehicleRoute.Direction == RouteConst.Routes.South)
                            vehicleRoute.Direction = RouteConst.Routes.East;
                        else
                            vehicleRoute.Direction = RouteConst.Routes.North;
                        
                        LocationControl(vehicleRoute);
                        break;
                    case 'R':
                        vehicleRoute = GetCurrentLocation(currentVehicle.Id);

                        if (vehicleRoute.Direction == RouteConst.Routes.North)
                            vehicleRoute.Direction = RouteConst.Routes.East;
                        else if (vehicleRoute.Direction == RouteConst.Routes.East)
                            vehicleRoute.Direction = RouteConst.Routes.South;
                        else if (vehicleRoute.Direction == RouteConst.Routes.South)
                            vehicleRoute.Direction = RouteConst.Routes.West;
                        else
                            vehicleRoute.Direction = RouteConst.Routes.North;
                        
                        LocationControl(vehicleRoute);
                        break;
                    default:
                        break;
                }
            }

            return new SuccessDataResult<Coordinate>(new Coordinate
            {
                Head = vehicleRoute.Direction,
                X = vehicleRoute.X,
                Y = vehicleRoute.Y
            },"İşlem Başarılı");
        } 

        public VehicleRoute GetCurrentLocation(Guid vehicleId)
        {
            return RouteRepository.GetVehicleRouteByVehicleId(vehicleId);
        }

        public IDataResult<Coordinate> LocationControl(VehicleRoute vehicleRoute)
        {
            VehicleRoute vehicle = RouteRepository.IsLocationSafe(vehicleRoute.X, vehicleRoute.Y, vehicleRoute.VehicleId);
            
            if (vehicle is not null)
                return new ErrorDataResult<Coordinate>("Hareket iptal edildi.");
        
            RouteRepository.Update(vehicleRoute);
            return new SuccessDataResult<Coordinate>("İşlem Başarılı");
        }
    }
}
