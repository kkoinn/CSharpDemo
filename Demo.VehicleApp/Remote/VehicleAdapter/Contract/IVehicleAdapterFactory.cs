using Demo.VehicleApp.Brand;

namespace Demo.VehicleApp.Remote.VehicleAdapter.Contract
{
	interface IVehicleAdapterFactory
	{
		IVehicleAdapter GetAdapter(VehicleBrand brand);
	}
}
