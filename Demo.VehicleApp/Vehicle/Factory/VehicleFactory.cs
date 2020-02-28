using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Vehicle.Behaviors;
using Demo.VehicleApp.Vehicle.Car;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Vehicle.Factory
{
	class VehicleFactory:IVehicleFactory
	{
		public ICar CreateCar(string modelCode, string model, VehicleBrand brand, CarType carType) 
		{
			switch (carType)
			{
				case CarType.Sedan:
					throw new ArgumentOutOfRangeException(nameof(carType), carType, null);
				case CarType.Suv:
					throw new ArgumentOutOfRangeException(nameof(carType), carType, null);
				default:
					throw new ArgumentOutOfRangeException(nameof(carType), carType, null);
			};
		}

		public ICar CreateScooter(string modelCode, string model, VehicleBrand brand)
		{
			throw new NotImplementedException();
		}
	}
}
