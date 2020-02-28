using System;
using System.Collections.Generic;
using System.Text;
using Demo.VehicleApp.Vehicle.Car;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Vehicle.Behaviors
{
	class BehaviorFactory
	{
		public static ICarBreakBehavior GetCarBreakBehavior(CarType carType)
		{
			switch (carType)
			{
				case CarType.Sedan:
					return new AbsBreakBehavior();
				case CarType.Suv:
					return new DrumBreakBehavior();
				default:
					throw new ArgumentOutOfRangeException(nameof(carType), carType, null);
			};
		}
	}
}
