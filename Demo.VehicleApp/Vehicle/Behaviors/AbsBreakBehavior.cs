using Demo.VehicleApp.Vehicle.Contract;
using Microsoft.Extensions.Logging;

namespace Demo.VehicleApp.Vehicle.Behaviors
{
	class AbsBreakBehavior:ICarBreakBehavior
	{
		public void Brake(ILogger log)
		{
			log.LogInformation($"hit breaks with abs behavior");
		}
	}
}
