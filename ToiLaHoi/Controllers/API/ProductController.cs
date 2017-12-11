using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToiLaHoi.Controllers.Resources;
using ToiLaHoi.Core;
using ToiLaHoi.Model;

namespace ToiLaHoi.Controllers.API
{

    [Route("/api/products")]
    public class ProductController : Controller
    {

        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IMapper mapper, IProductRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductResources productResources)
        {
           

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = mapper.Map<SaveProductResources, Product>(productResources);
            

            repository.Add(product);
            await unitOfWork.CompleteAsync();

            product = await repository.GetProductID(product.Id);

            var result = mapper.Map<Product, ProductResources>(product);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] SaveProductResources productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await repository.GetProductID(id);

            if (product == null)
                return NotFound();

            mapper.Map<SaveProductResources, Product>(productResource, product);
            

            await unitOfWork.CompleteAsync();

            product = await repository.GetProductID(product.Id);
            var result = mapper.Map<Product, SaveProductResources>(product);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var product = await repository.GetProductID(id);

            if (product == null)
                return NotFound();

            repository.Remove(product);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        // get product by ID :))
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductID(int id)
        {
            var product = await repository.GetProductID(id);

            if (product == null)
                return NotFound();

            var productResource = mapper.Map<Product, ProductResources>(product);

            return Ok(productResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduct(int id)
        {
            var product = await repository.GetProductID(id, includeRelated: false);

            if (product == null)
                return NotFound();

            repository.Remove(product);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }



        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await repository.GetProduct();

            if (products == null)
                return NotFound();
          
               var productResources=mapper.Map< IEnumerable<Product>, IEnumerable<ProductResources>>(products);
         

            return Ok(productResources);
        }










    }
}