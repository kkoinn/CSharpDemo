using System;
using Demo.VehicleApp.Brand;
using Demo.VehicleApp.Local.Repository;
using Demo.VehicleApp.Local.Service;
using Demo.VehicleApp.Remote.VehicleAdapter;
using Demo.VehicleApp.Remote.VehicleAdapter.Contract;
using Demo.VehicleApp.Vehicle;
using Demo.VehicleApp.Vehicle.Behaviors;
using Demo.VehicleApp.Vehicle.Car;
using Demo.VehicleApp.Vehicle.Contract;
using Demo.VehicleApp.Vehicle.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace Demo.VehicleApp
{
	class Program
	{
		private static readonly ILogger<Program> Log;
		private static readonly IVehicleAdapterFactory VehicleAdapterFactory;
		private static readonly IVehicleService VehicleService;
		static Program()
		{
			ServiceCollection serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
			Log = serviceProvider.GetService<ILogger<Program>>();
			VehicleAdapterFactory = serviceProvider.GetService<IVehicleAdapterFactory>();
			VehicleService = serviceProvider.GetService<IVehicleService>();
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Starting vehicle app");
			//IServiceProvider serviceProvider = ConfigureIoc(serviceCollection);

			VehicleService.InsertVehicle(new
					CarBuilder()
				.SetModelInfo("HH999", "Civic")
				.SetBrand(VehicleBrand.Honda)
				.SetCarType(CarType.Sedan)
				.ApplyBehavior(BehaviorFactory.GetCarBreakBehavior(CarType.Sedan))
				.SetCarType(CarType.Sedan)
				.Build());
			VehicleService.InsertVehicle(new
					CarBuilder()
				.SetModelInfo("HH111", "XR90")
				.SetBrand(VehicleBrand.Honda)
				.SetCarType(CarType.Sedan)
				.ApplyBehavior(BehaviorFactory.GetCarBreakBehavior(CarType.Suv))
				.SetCarType(CarType.Suv)
				.Build());
			VehicleService.InsertVehicle(new
					CarBuilder()
				.SetModelInfo("XX999", "V40")
				.SetBrand(VehicleBrand.Volvo)
				.SetCarType(CarType.Sedan)
				.ApplyBehavior(BehaviorFactory.GetCarBreakBehavior(CarType.Sedan))
				.Build());
			VehicleService.InsertVehicle(new
					CarBuilder()
				.SetModelInfo("XX111", "V90")
				.SetBrand(VehicleBrand.Volvo)
				.SetCarType(CarType.Sedan)
				.ApplyBehavior(BehaviorFactory.GetCarBreakBehavior(CarType.Sedan))
				.Build());
			VehicleService.InsertVehicle(new CustomizedCarBuilder(new
						CarBuilder()
					.SetModelInfo("XX222", "XC90")
					.SetBrand(VehicleBrand.Volvo)
					.SetCarType(CarType.Suv)
					.ApplyBehavior(BehaviorFactory.GetCarBreakBehavior(CarType.Suv)).Build())
				.SetCustomCarTrunkText("Coolest trunk text in town")
				.Build());

			//var hondaAdapter = serviceProvider.GetService<IVehicleAdapterFactory>().GetAdapter(VehicleBrand.Honda);
			//var volvoAdapter = serviceProvider.GetService<IVehicleAdapterFactory>().GetAdapter(VehicleBrand.Volvo);
			//hondaAdapter.CreateVehicle(Suv.Init("HH999", "Civic", VehicleBrand.Honda));
			//volvoAdapter.CreateVehicle(Sedan.Init("XX999", "V40", VehicleBrand.Volvo));

			//var honda = hondaAdapter.GetVehicle("HH999");

			Log.LogInformation("List all local cars");
			VehicleService.ListVehicles().ForEach(v =>
			{
				v.PrintDetails(Log);
				v.BreakBehavior?.Brake(Log);
			});
			Log.LogInformation("List all remote volvo cars");
			VehicleAdapterFactory.GetAdapter(VehicleBrand.Volvo).GetVehicles().ForEach(v =>
			{
				v.PrintDetails(Log);
				v.BreakBehavior?.Brake(Log);
			});
			Console.ReadKey();
		}

		private static void ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddLogging(c => c.AddConsole());
			serviceCollection.AddSingleton<IRepository<ICar>, VehicleRepository>();
			serviceCollection.AddTransient<IVehicleService, VehicleService>();
			serviceCollection.AddTransient<IVehicleAdapter, HondaAdapter>();
			serviceCollection.AddTransient<IVehicleAdapter, VolvoAdapter>();
			serviceCollection.AddTransient<IVehicleAdapterFactory, VehicleAdapterFactory>();
			serviceCollection.AddTransient<IVehicleFactory, VehicleFactory>();

		}
		public static IServiceProvider ConfigureIoC(IServiceCollection services)
		{
			services.AddLogging(c => c.AddConsole());
			var container = new Container();
			container.Configure(config =>
			{
				// Register stuff in container, using the StructureMap APIs...
				config.Scan(_ =>
				{
					_.AssemblyContainingType(typeof(Program));
					_.AddAllTypesOf<IVehicleAdapterFactory>();
				});
				//Populate the container using the service collection
				config.Populate(services);
			});

			return container.GetInstance<IServiceProvider>();

		}
	}
}
