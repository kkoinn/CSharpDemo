using System.Collections.Generic;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Remote.VehicleAdapter.Contract
{
	interface IVehicleAdapter
	{
		void CreateVehicle(ICar vehicle);
		ICar GetVehicle(string modelCode);
		List<ICar> GetVehicles();
		bool IsValidAdapterRequest(VehicleBrand brand);
	}
}
