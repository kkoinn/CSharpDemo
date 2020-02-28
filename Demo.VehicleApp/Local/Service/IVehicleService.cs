using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Demo.VehicleApp.Local.Repository;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Local.Service
{
	interface IVehicleService
	{
		ICar GetVehicleById(int id);
		ICar GetVehicleByModelCode(string modelCode);
		List<ICar> ListVehicles();
		List<ICar> FindAllVehiclesModelsByStringExpression(string expression);
		void InsertVehicle(ICar entity);
		void DeleteVehicle(ICar entity);
		void UpdateVehicle(ICar entity);
		void UpdateVehicleById(int id);
	}
}
