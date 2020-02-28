using System.Collections.Generic;
using Demo.VehicleApp.Remote.Cars;

namespace Demo.VehicleApp.Remote.Repository
{
	class VolvoRepositorySingleton
	{
		private static VolvoRepositorySingleton _instance;
		private static object _syncLock = new object();
		private readonly List<Volvo> _volvos = new List<Volvo>();
		VolvoRepositorySingleton()
		{
			_volvos.Add(Volvo.Create("V90", "XX1212"));
			_volvos.Add(Volvo.Create("XC60", "XX3344"));
		}

		public static VolvoRepositorySingleton Instance()
		{
			if (_instance == null)
			{
				lock (_syncLock)
				{
					if (_instance == null)
					{
						_instance = new VolvoRepositorySingleton();
					}
				}
			}

			return _instance;
		}

		public void Add(Volvo vehicle)
		{
			lock (_syncLock)
			{
				_volvos.Add(vehicle);
			}
		}

		public Volvo GetVehicle(string modelCode)
		{
			return _volvos.Find(p => p.Code == modelCode);
		}
		public List<Volvo> GetVehicles()
		{
			return _volvos;
		}
	}

}