using System.Collections.Generic;
using System.Linq;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Remote.VehicleAdapter.Contract;

namespace Demo.VehicleApp.Remote.VehicleAdapter
{
	class VehicleAdapterFactory:IVehicleAdapterFactory
	{
		public IEnumerable<IVehicleAdapter> Adapters { get; }

		public VehicleAdapterFactory(IEnumerable<IVehicleAdapter> adapters)
		{
			Adapters = adapters;
		}
		public IVehicleAdapter GetAdapter(VehicleBrand brand)
		{
			return Adapters.Single(adapter => adapter.IsValidAdapterRequest(brand));
		}
	}
}
