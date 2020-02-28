using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Demo.VehicleApp.Vehicle.Contract;

namespace Demo.VehicleApp.Local.Repository
{ 
	class VehicleRepository:IRepository<ICar>
	{
		private readonly List<ICar> _vehicles = new List<ICar>();
		public ICar Get(int id)
		{
			throw new NotImplementedException();
		}

		public ICar Get(string modelCode)
		{
			return _vehicles.Single(vehicle => vehicle.ModelCode == modelCode);
		}

		public IEnumerable<ICar> List()
		{
			return _vehicles;
		}

		public IEnumerable<ICar> List(Expression<Func<ICar, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public void Create(ICar entity)
		{
			_vehicles.Add(entity);
		}

		public void Delete(ICar entity)
		{
			throw new NotImplementedException();
		}

		public void Update(ICar entity)
		{
			throw new NotImplementedException();
		}

		public void Update(int id)
		{
			throw new NotImplementedException();
		}
	}
}
