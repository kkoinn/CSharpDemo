using System.Transactions;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Vehicle.Contract;
using Microsoft.Extensions.Logging;

namespace Demo.VehicleApp.Vehicle.Car
{
	class CustomizedCar : ICar
	{
		public CustomizedCar(Car car)
		{
			ModelCode = car.ModelCode;
			Model = car.Model;
			Brand = car.Brand;
			Type = car.Type;
			BreakBehavior = car.BreakBehavior;
		}
		public string CustomTrunkText { get; set; }
		public string ModelCode { get; set; }
		public string Model { get; set; }
		public VehicleBrand Brand { get; set; }
		public CarType Type { get; set; }
		public ICarBreakBehavior BreakBehavior { get; set; }

		public void PrintDetails(ILogger log)
		{
			log.LogInformation($"Car has this customizations {CustomTrunkText}");
		}

	}
}