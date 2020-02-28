using System.Collections.Generic;
using Demo.VehicleApp.Remote.Cars;
using Demo.VehicleApp.Remote.Repository;

namespace Demo.VehicleApp.Proxy
{
	class HondaApiProxy
	{
		private readonly HondaRepositorySingleton _hondaRemoteRepository = HondaRepositorySingleton.Instance();
		
		public void Add(Honda honda)
		{
			_hondaRemoteRepository.Add(honda);
		}
		public Honda GetVehicle(string modelCode)
		{
			return _hondaRemoteRepository.GetVehicle(modelCode);
		}
		public List<Honda> GetVehicles()
		{
			return _hondaRemoteRepository.GetVehicles();
		}
	}
}
