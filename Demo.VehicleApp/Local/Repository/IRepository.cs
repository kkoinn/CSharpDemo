using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Demo.VehicleApp.Local.Repository
{   
	public interface IRepository<T> 
	{
			T Get(int id);
			T Get(string modelCode);
			IEnumerable<T> List();
			IEnumerable<T> List(Expression<Func<T, bool>> predicate);
			void Create(T entity);
			void Delete(T entity);
			void Update(T entity);
			void Update(int id);

	}
}

/*
 * public interface IMaintainable : IDisposable
    {
       T Single<T>(Expression<Func<T, bool>> expression) where T : class, new();
       System.Linq.IQueryable<T> All<T>() where T : class, new();
       void Add<T>(T item) where T : class, new();
       void Update<T>(T item) where T : class, new();
       void Delete<T>(T item) where T : class, new();
       void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new();
       void DeleteAll<T>() where T : class, IEntity, new();
       void CommitChanges();
    }*/
 
