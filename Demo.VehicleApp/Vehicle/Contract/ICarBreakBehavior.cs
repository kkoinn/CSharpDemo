using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Demo.VehicleApp.Vehicle.Contract
{
	public interface ICarBreakBehavior
	{
		void Brake(ILogger log);
	}
}
