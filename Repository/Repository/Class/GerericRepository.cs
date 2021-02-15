using Microsoft.EntityFrameworkCore;
using Model.Database;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository.Class
{
    public class GerericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly CompanyDBContext context;
        readonly DbSet<T> table;
        public GerericRepository(CompanyDBContext context) 
        {
            this.context = context;
            table = context.Set<T>();
        }

        public void Delete(object id)
        {
            T record = table.Find(id);
            table.Remove(record);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
