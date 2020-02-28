using System;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Vehicle.Car;
using Microsoft.Extensions.Logging;

namespace Demo.VehicleApp.Vehicle.Contract
{
	public interface ICar
	{
		string ModelCode { get; set; }
		string Model { get; set; }
		VehicleBrand Brand { get; set; } 
		CarType Type { get; set; }
		ICarBreakBehavior BreakBehavior { get; set; }

		void PrintDetails(ILogger log);
	}
}
