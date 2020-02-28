using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Vehicle.Contract;
using Microsoft.Extensions.Logging;

namespace Demo.VehicleApp.Vehicle.Car
{
	class Car : ICar
	{
		public string ModelCode { get; set; }
		public string Model { get; set; }
		public VehicleBrand Brand { get; set; }
		public CarType Type { get; set; }
		public ICarBreakBehavior BreakBehavior { get; set; }

		public virtual void PrintDetails(ILogger log)
		{
			log.LogInformation($"Type: {GetType().Name} ModelCode: {ModelCode} Model: {Model} Brand: {Brand}");
		}

	}
}

