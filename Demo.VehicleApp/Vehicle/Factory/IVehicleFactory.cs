using System;
using System.Collections.Generic;
using System.Text;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Remote.VehicleAdapter.Contract;
using Demo.VehicleApp.Vehicle.Car;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Vehicle.Factory
{
	interface IVehicleFactory
	{
		ICar CreateCar(string modelCode, string model, VehicleBrand brand, CarType carType);
		ICar CreateScooter(string modelCode, string model, VehicleBrand brand);
	}
}
