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
    public class BrandController : ControllerBase
    {
        private readonly IGenericRepository<Brand> genericRepository;

        public BrandController() 
        {
            genericRepository = new GerericRepository<Brand>(new CompanyDBContext());
        }

        // GET: api/Brand
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return genericRepository.GetAll();
        }

        // GET: api/Brand/5
        [HttpGet("{id}", Name = "Get")]
        public Brand Get(int id)
        {
            return genericRepository.GetById(id);
        }

        // POST: api/Brand
        [HttpPost]
        public void Post([FromBody] Brand brand)
        {
            genericRepository.Insert(brand);
            genericRepository.Save();
        }

        // PUT: api/Brand/5
        [HttpPut]
        public void Put([FromBody] Brand brand)
        {
            genericRepository.Update(brand);
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
