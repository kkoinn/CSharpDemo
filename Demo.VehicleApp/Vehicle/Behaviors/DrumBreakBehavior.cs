using Demo.VehicleApp.Vehicle.Contract;
using Microsoft.Extensions.Logging;

namespace Demo.VehicleApp.Vehicle.Behaviors
{
	class DrumBreakBehavior:ICarBreakBehavior
	{
		public void Brake(ILogger log)
		{
			log.LogInformation($"Hit brakes with Drum behavior");
		}
	}
}
