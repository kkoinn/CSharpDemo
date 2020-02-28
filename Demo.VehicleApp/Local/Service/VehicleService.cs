using System.Collections.Generic;
using System.Linq;
using Demo.VehicleApp.Local.Repository;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Local.Service
{
	class VehicleService:IVehicleService
	{
		private readonly IRepository<ICar> _vehicleRepository;

		public VehicleService(IRepository<ICar> vehicleRepository)
		{
			_vehicleRepository = vehicleRepository;
		}

		public ICar GetVehicleById(int id)
		{
			return _vehicleRepository.Get(id);
		}

		public ICar GetVehicleByModelCode(string modelCode)
		{
			return _vehicleRepository.Get(modelCode);
		}

		public List<ICar> ListVehicles()
		{
			return _vehicleRepository.List().ToList();
		}

		public List<ICar> FindAllVehiclesModelsByStringExpression(string expression)
		{
			return _vehicleRepository.List(vehicle => vehicle.Model.Contains(expression)).ToList();
		}

		public void InsertVehicle(ICar entity)
		{
			_vehicleRepository.Create(entity);
		}

		public void DeleteVehicle(ICar entity)
		{
			throw new System.NotImplementedException();
		}

		public void UpdateVehicle(ICar entity)
		{
			throw new System.NotImplementedException();
		}

		public void UpdateVehicleById(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
