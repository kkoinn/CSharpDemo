using System;
using System.ComponentModel;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Vehicle.Car
{
	// fluent interface pattern
	internal class CarBuilder
	{
		private readonly Car _car = new Car();

		public CarBuilder SetModelInfo(string modelCode, string model)
		{
			_car.Model = model;
			_car.ModelCode = modelCode;
			return this;
		}

		public CarBuilder SetCarType(CarType carType)
		{
			_car.Type = carType;
			return this;
		}

		public CarBuilder SetBrand(VehicleBrand brand)
		{
			_car.Brand = brand;
			return this;
		}

		public CarBuilder ApplyBehavior(ICarBreakBehavior carBreakBreakBehavior)
		{
			_car.BreakBehavior = carBreakBreakBehavior;
			return this;
		}

		public Car Build()
		{
			Validate();
			return _car;
		}

		private void Validate()
		{
			if (_car == null) throw new NullReferenceException();

			if (string.IsNullOrEmpty(_car.Model)) throw new NullReferenceException($"{nameof(_car.Model)}");
			if (string.IsNullOrEmpty(_car.ModelCode)) throw new NullReferenceException($"{nameof(_car.Model)}");
			if (!Enum.IsDefined(typeof(CarType), _car.Type)) throw new InvalidEnumArgumentException(nameof(_car.Type), (int) _car.Type, typeof(CarType));
		}
	}
}