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
	class VolvoAdapter : IVehicleAdapter
	{
		readonly VolvoApiProxy _volvoVehicle = new VolvoApiProxy();
		public void CreateVehicle(ICar vehicle)
		{
			Volvo volvo = Volvo.Create(vehicle.Model, vehicle.ModelCode);
			_volvoVehicle.BuildYourVolvo(volvo);
		}

		public ICar GetVehicle(string modelCode)
		{
			Volvo volvo = _volvoVehicle.GetVolvo(modelCode);
			return new CarBuilder().SetModelInfo(volvo.Code, volvo.Model).SetBrand(VehicleBrand.Volvo).Build();
		}

		public List<ICar> GetVehicles()
		{
			var volvos = _volvoVehicle.GetVolvos().Select(volvo => (ICar)new CarBuilder().SetModelInfo(volvo.Code, volvo.Model).SetBrand(VehicleBrand.Volvo).Build());
			return volvos.ToList();
		}

		public bool IsValidAdapterRequest(VehicleBrand brand)
		{
			return brand == VehicleBrand.Volvo;
		}
	}
}
