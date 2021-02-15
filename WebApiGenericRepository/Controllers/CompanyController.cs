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
    public class CompanyController : ControllerBase
    {
        private readonly IGenericRepository<Company> genericRepository;

        public CompanyController() 
        {
            genericRepository = new GerericRepository<Company>( new CompanyDBContext() );
        } 

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return genericRepository.GetAll();
        }

        [HttpGet("{id}", Name = "Geto")]
        public Company Get(int id)
        {
            return genericRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Company company)
        {
            genericRepository.Insert(company);
            genericRepository.Save();
        }

        [HttpPut]
        public void Put([FromBody] Company company)
        {
            genericRepository.Update(company);
            genericRepository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            genericRepository.Delete(id);
            genericRepository.Save();
        }
    }
}
