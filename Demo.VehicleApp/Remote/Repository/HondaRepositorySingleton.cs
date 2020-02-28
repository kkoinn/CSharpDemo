using System.Collections.Generic;
using Demo.VehicleApp.Remote.Cars;

namespace Demo.VehicleApp.Remote.Repository
{
	class HondaRepositorySingleton
	{
		private static HondaRepositorySingleton _instance;
		private static object _syncLock = new object();
		private readonly List<Honda> _hondas = new List<Honda>();
		HondaRepositorySingleton()
		{
			_hondas.Add(Honda.Create("CR-V", "HH7383"));
			_hondas.Add(Honda.Create("HR-V", "HH3434"));
		}

		public static HondaRepositorySingleton Instance()
		{
			if (_instance == null)
			{
				lock (_syncLock)
				{
					if (_instance == null)
					{
						_instance = new HondaRepositorySingleton();
					}
				}
			}

			return _instance;
		}

		public void Add(Honda vehicle)
		{
			lock (_syncLock)
			{
				_hondas.Add(vehicle);
			}
		}

		public Honda GetVehicle(string modelCode)
		{
			return _hondas.Find(p=> p.Code == modelCode);
		}
		public List<Honda> GetVehicles()
		{
			return _hondas;
		}
	}
	
}
