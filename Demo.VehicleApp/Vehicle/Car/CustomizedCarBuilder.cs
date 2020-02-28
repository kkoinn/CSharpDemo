using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Vehicle.Car
{
	// fluent interface pattern
	internal class CustomizedCarBuilder
	{
		private  CustomizedCar _car;

		public CustomizedCarBuilder(Car car)
		{
			_car = new CustomizedCar(car);
		}

		public CustomizedCarBuilder SetCustomCarTrunkText(string customCarTrunkText)
		{
			_car.CustomTrunkText = customCarTrunkText;
			return this;
		}

		public CustomizedCar Build()
		{
			Validate();
			return _car;
		}

		private void Validate()
		{
			if (_car.CustomTrunkText == "") throw new ArgumentException($"{nameof(_car.Model)} cannot be empty"  );
		}
	}
}