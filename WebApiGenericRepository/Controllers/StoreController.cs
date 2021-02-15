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
    public class StoreController : ControllerBase
    {
        readonly IGenericRepository<Store> genericRepository;

        public StoreController() 
        {
            genericRepository = new GerericRepository<Store>( new CompanyDBContext());
        }

        // GET: api/Store
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            return genericRepository.GetAll();
        }

        // GET: api/Store/5
        [HttpGet("{id}", Name = "Get")]
        public Store Get(int id)
        {
            return genericRepository.GetById(id);
        }

        // POST: api/Store
        [HttpPost]
        public void Post([FromBody] Store store)
        {
            genericRepository.Insert(store);
            genericRepository.Save();
        }

        // PUT: api/Store/5
        [HttpPut]
        public void Put([FromBody] Store store)
        {
            genericRepository.Update(store);
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
