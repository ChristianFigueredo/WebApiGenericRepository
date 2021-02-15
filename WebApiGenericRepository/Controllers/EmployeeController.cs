using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Database;
using Repository.Repository.Class;
using Repository.Repository.Interface;

namespace WebApiGenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IGenericRepository<Employee> genericRepository;

        public EmployeeController() 
        {
            genericRepository = new GerericRepository<Employee>(new CompanyDBContext());
        }

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return genericRepository.GetAll();
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return genericRepository.GetById(id);
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            genericRepository.Insert(employee);
            genericRepository.Save();
        }

        // PUT: api/Employee/5
        [HttpPut]
        public void Put([FromBody] Employee employee)
        {
            genericRepository.Update(employee);
            genericRepository.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            genericRepository.Delete(id);
            genericRepository.Save();
        }
    }
}
