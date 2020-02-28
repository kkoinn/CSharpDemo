using System.Collections.Generic;
using Demo.VehicleApp.Remote.Cars;
using Demo.VehicleApp.Remote.Repository;
using Demo.VehicleApp.Vehicle;

namespace Demo.VehicleApp.Proxy
{
	class VolvoApiProxy
	{
		private readonly VolvoRepositorySingleton _volvoRepositorySingleton = VolvoRepositorySingleton.Instance();
		public void BuildYourVolvo(Volvo vehicle)
		{
			_volvoRepositorySingleton.Add(vehicle);
		}
		public Volvo GetVolvo(string modelCode)
		{
			return _volvoRepositorySingleton.GetVehicle(modelCode);
		}
		public List<Volvo> GetVolvos()
		{
			return _volvoRepositorySingleton.GetVehicles();
		}
	}
}
