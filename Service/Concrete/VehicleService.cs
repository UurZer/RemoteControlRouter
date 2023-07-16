using Rcr.Data.Entity;
using Rcr.Data.Repository;
using Rcr.Service.Abstract;
using Rcr.Utilities.Consts;
using Rcr.Utilities.Results;
using IResult = Rcr.Utilities.Results.IResult;

namespace Rcr.Service.Concrete
{
    public class VehicleService : IVehicleService
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

        public IResult SaveVehicle(Vehicle vehicle)
        {
            Vehicle currentVehicle = VehicleRepository.GetVehicleById(vehicle.Id);

            if (currentVehicle is null)
            {
                if(vehicle.Id == Guid.Empty)
                    vehicle.Id = new Guid();
                vehicle.CreatedDate = DateTime.Now;

                VehicleRepository.Add(vehicle);
                
                RouteRepository.Add(new VehicleRoute
                {
                    Id = vehicle.Route.Id == Guid.Empty ? new Guid() : vehicle.Route.Id,
                    X = 0,
                    Y = 0,
                    VehicleId = vehicle.Id,
                    Direction = RouteConst.Routes.North,
                    CreatedDate = DateTime.Now,
                });
            }
            else
                VehicleRepository.Update(vehicle);

            return new SuccessResult();
        }

        public IDataResult<List<Vehicle>> GetSurface()
        {
            List<Vehicle> currentVehicles = VehicleRepository.GetActiveVehicles();

            if(currentVehicles is null)
                return new ErrorDataResult<List<Vehicle>>("İşlem başarısız.");
            
            return new SuccessDataResult<List<Vehicle>>(currentVehicles, "İşlem başarılı");
        }
    }
}
