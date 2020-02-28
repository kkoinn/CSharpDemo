using System.Collections.Generic;
using System.Linq;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Proxy;
using Demo.VehicleApp.Remote.Cars;
using Demo.VehicleApp.Remote.VehicleAdapter.Contract;
using Demo.VehicleApp.Vehicle;
using Demo.VehicleApp.Vehicle.Car;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Remote.VehicleAdapter
{
	class HondaAdapter:IVehicleAdapter
	{
		readonly HondaApiProxy _hondaVehicle = new HondaApiProxy();

		public void CreateVehicle(ICar vehicle)
		{
			_hondaVehicle.Add(Honda.Create(vehicle.Model,vehicle.ModelCode));
		}

		public ICar GetVehicle(string modelCode)
		{
			Honda honda = _hondaVehicle.GetVehicle(modelCode);
			return new CarBuilder().SetModelInfo(honda.Code, honda.Model).SetBrand(VehicleBrand.Honda).Build();
		}

		public List<ICar> GetVehicles()
		{
			var hondas = _hondaVehicle.GetVehicles().Select(honda => new CarBuilder().SetModelInfo(honda.Code, honda.Model).SetBrand(VehicleBrand.Honda).Build() as ICar);
			return hondas.ToList();
		}

		public bool IsValidAdapterRequest(VehicleBrand brand)
		{
			return brand == VehicleBrand.Honda;
		}
	}
}
