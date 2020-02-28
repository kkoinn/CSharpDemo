using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Demo.CSharpExamples.Contracts;

namespace Demo.CSharpExamples
{
	class FactoryComparison:IPrint
	{
		FactoryComparison()
		{

		}
		Number _number = new Number().next();

		public void Print()
		{
			return;
		}
	}

//Creation method
	class Number
	{
		private int _value;

		public Number()
		{
			_value = 0;
		}
		public Number(int value)
		{
			_value = value;
		}

		public Number next()
		{
			return new Number(_value + 1);
		}
	}

//Static creation method
	class User
	{
		private int Id;
		private string Name;
		private string Email; 
		private long Phone;

		private User(int id, string name, string email, long phone)
		{
			Id = id;
			Name = name;
			Email = email;
			Phone = phone;
		}

		public static User Load(int userId)
		{
			var userById = FindUserById(userId);
			return new User(userById.id, userById.name, userById.email, userById.phone); 
		}
		private static (int id, string name, string email, long phone) FindUserById(int id)
		{
			return (1, "kod", "kod@gmail.com", 99999);
		}
	}
//simple factory
	class UserFactory
	{
		public static object Create(string type) => type switch
			{
			"user" => User.Load(1),
			"number" => new Number(),
			_ => throw new Exception("Wrong type passed.")
			/*			 
		switch (type) {
        case "user": return User.Load(1);
        case "number": return new Number();
			default:
            throw new Exception("Wrong type passed.");
		}*/
			/*return type switch
		{
			"user" => User.Load(1),
			"number" => new Number(),
			_ => throw new Exception("Wrong type passed."),
		};*/
			};
	}

// factory pattern, When client need an object for a specific job, but client doesn’t care about what concrete class is suitable for the job, Factory decides for it, it creates and return the suitable object.
	class LogisticsSimpleFactoryApp
	{
		public static void Run()
		{
			ITransport transport = TransportSimpleFactory.GetDeliveryTransport("sweden");
			transport.Deliver();
		}
		class TransportSimpleFactory
		{
			public static ITransport GetDeliveryTransport(string country) => country switch
				{
				"sweden" => new Truck(),
				"scottland" => new Ship(),
				_ => throw new ArgumentException("no country like that specified")
				};

		}
	}

	public class LogisticApp
	{
		public static void Run()
		{
			ITransportFactory transportFactory = new TransportFactory();
			ITransport transport = transportFactory.GetTransport("sweden");
			transport.Deliver();
		}
	}

//creator
	interface ITransportFactory
	{ 
		ITransport GetTransport(string type);
	}

//concrete creators
	class TransportFactory : ITransportFactory
	{
		public ITransport GetTransport(string type) => type switch
			{
			"sweden" => new Truck(),
			"scottland" => new Ship(),
			_ => throw new ArgumentException("no country like that specified")
			};
	}

//Product
	interface ITransport
	{ 
		void Deliver();
	}
//Concrete products
	class Truck:ITransport
	{
		public void Deliver()
		{
			throw new NotImplementedException();
		}
	}
	class Ship:ITransport
	{
		public void Deliver()
		{
			throw new NotImplementedException();
		}
	}

	class AbstractFactoryApp
	{
		void Run()
		{
		
		}
	}

	class VehicleClient
	{
		public IVehicleFactory VechicleFactory { get; }

		public VehicleClient(IVehicleFactory vechicleFactory)
		{
			VechicleFactory = vechicleFactory;
		}
		public string GetBikeName(string type)
		{
			return VechicleFactory.GetBike(type).Name();
		}

		public string GetScooterName(string type)
		{
			return VechicleFactory.GetScooter(type).Name();
		}
	}

	interface IVehicleFactory
	{
		IBike GetBike(string Bike);
		IScooter GetScooter(string Scooter);
		void CreateBike(IBike bike);
	}

	class HeroFactory:IVehicleFactory
	{
		public IBike GetBike(string Bike)
		{
			switch (Bike)
			{
				case "Sports":
					return new SportsBike();
				case "Regular":
					return new RegularBike();
				default:
					throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
			}
		}

		public IScooter GetScooter(string Scooter)
		{
			switch (Scooter)
			{
				case "Sports":
					return new Scooty();
				case "Regular":
					return new RegularScooter();
				default:
					throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
			}
		}

		public void CreateBike(IBike bike)
		{
			throw new NotImplementedException();
		}
	}

	class HondaFactory : IVehicleFactory
	{
		public IBike GetBike(string Bike)
		{
			switch (Bike)
			{
				case "Sports":
					return new SportsBike();
				case "Regular":
					return new RegularBike();
				default:
					throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
			}
		}

		public IScooter GetScooter(string Scooter)
		{
			switch (Scooter)
			{
				case "Sports":
					return new Scooty();
				case "Regular":
					return new RegularScooter();
				default:
					throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
			}
		}

		public void CreateBike(IBike bike)
		{
			throw new NotImplementedException();
		}
	}

//Products
	/// <summary>
	/// The 'AbstractProductA' interface
	/// </summary>
	interface IBike
	{
		string Name();
	}

	/// <summary>
	/// The 'AbstractProductB' interface
	/// </summary>
	interface IScooter
	{
		string Name();
	}

	/// <summary>
	/// The 'ProductA1' class
	/// </summary>
	class RegularBike : IBike
	{
		public string Name()
		{
			return "Regular Bike- Model";
		}
	}

	/// <summary>
	/// The 'ProductA2' class
	/// </summary>
	class SportsBike : IBike
	{
		public string Name()
		{
			return "Sports Bike- Model";
		}
	}

	/// <summary>
	/// The 'ProductB1' class
	/// </summary>
	class RegularScooter : IScooter
	{
		public string Name()
		{
			return "Regular Scooter- Model";
		}
	}

	/// <summary>
	/// The 'ProductB2' class
	/// </summary>
	class Scooty : IScooter
	{
		public string Name()
		{
			return "Scooty- Model";
		}
	}

	class VehicleBuilderApp
	{
		readonly IVehicleBuilder _builder = new HondaBuilder();
		public void Run()
		{
			VehicleCreator creator = new VehicleCreator(_builder);
			creator.CreateVehicle();
			Vehicle vehicle = creator.GetVehicle();
			vehicle.ShowInfo();

		}
	}
	class VehicleCreator
	{
		private readonly IVehicleBuilder _vehicleBuilder;
		public VehicleCreator(IVehicleBuilder vehicleBuilder)
		{
			_vehicleBuilder = vehicleBuilder;
		}

		public void CreateVehicle()
		{
			_vehicleBuilder.SetModel();
			_vehicleBuilder.SetEngine();
			_vehicleBuilder.SetBody();
			_vehicleBuilder.SetTransmission();
			_vehicleBuilder.SetAccessories();
		}

		public Vehicle GetVehicle()
		{
			return _vehicleBuilder.GetVehicle();
		}
	}
	interface IVehicleBuilder
	{
		void SetModel();
		void SetEngine();
		void SetTransmission();
		void SetBody();
		void SetAccessories();
		Vehicle GetVehicle();
	}
	class HondaBuilder:IVehicleBuilder
	{
		readonly Vehicle _vehicle = new Vehicle();

		public void SetModel()
		{
			_vehicle.Model = "Hero";
		}

		public void SetEngine()
		{
			_vehicle.Engine = "4 Stroke";
		}

		public void SetTransmission()
		{
			_vehicle.Transmission = "120 km/hr";
		}

		public void SetBody()
		{
			_vehicle.Body = "Plastic";
		}

		public void SetAccessories()
		{
			_vehicle.Accessories.Add("Seat Cover");
			_vehicle.Accessories.Add("Rear Mirror");
		}

		public Vehicle GetVehicle()
		{
			return _vehicle;
		}
	}

	class Vehicle
	{
		public string Model { get; set; }
		public string Engine { get; set; }
		public string Transmission { get; set; }
		public string Body { get; set; }
		public List<string> Accessories { get; set; }

		public Vehicle()
		{
			Accessories = new List<string>();
		}

		public void ShowInfo()
		{
			Console.WriteLine("Model: {0}", Model);
			Console.WriteLine("Engine: {0}", Engine);
			Console.WriteLine("Body: {0}", Body);
			Console.WriteLine("Transmission: {0}", Transmission);
			Console.WriteLine("Accessories:");
			foreach (var accessory in Accessories)
			{
				Console.WriteLine("\t{0}", accessory);
			}
		}
	}
}