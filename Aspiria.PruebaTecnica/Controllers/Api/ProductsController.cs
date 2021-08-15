using Aspiria.PruebaTecnica.Data;
using Aspiria.PruebaTecnica.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aspiria.PruebaTecnica.Controllers.Api
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductRepository repository;
        public ProductsController(ProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get(string searchString = "")
        {
            return repository.Find(searchString);
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return repository.Find(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                if (repository.Save(product))
                {
                    return new JsonResult(product);
                }
            }
            return BadRequest();
        }

        // PUT api/<ProductsController>/5
        [HttpPatch("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            if(repository.Find(id) != null)
            {
                product.Id = id;
                repository.Update(product);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
