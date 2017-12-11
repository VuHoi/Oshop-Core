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

    [Route("/api/shoppingcart")]
    public class ShoppingCartController : Controller
    {

        private readonly IMapper mapper;
        private readonly IShoppingCartRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ShoppingCartController(IMapper mapper, IShoppingCartRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingCart([FromBody] SaveShoppingCartResources ShoppingCartResources)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ShoppingCart = mapper.Map<SaveShoppingCartResources, ShoppingCart>(ShoppingCartResources);


            repository.Add(ShoppingCart);
            await unitOfWork.CompleteAsync();

            ShoppingCart = await repository.GetShoppingCartId(ShoppingCart.Id);

            var result = (mapper.Map<ShoppingCart, ShoppingCartResources>(ShoppingCart));
           
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoppingCart(int id, [FromBody] SaveShoppingCartResources ShoppingCartResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ShoppingCart = await repository.GetShoppingCartId(id);

            if (ShoppingCart == null)
                return NotFound();

            mapper.Map<SaveShoppingCartResources, ShoppingCart>(ShoppingCartResource, ShoppingCart);


            await unitOfWork.CompleteAsync();

            ShoppingCart = await repository.GetShoppingCartId(ShoppingCart.Id);
            var result = mapper.Map<ShoppingCart, SaveShoppingCartResources>(ShoppingCart);

            return Ok(result);
        }

      

        // get ShoppingCart by ID :))
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingCartID(int id)
        {
            var ShoppingCart = await repository.GetShoppingCartId(id);

            if (ShoppingCart == null)
                return NotFound();

            var ShoppingCartResource = mapper.Map<ShoppingCart, ShoppingCartResources>(ShoppingCart);

            return Ok(ShoppingCartResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            var ShoppingCart = await repository.GetShoppingCartId(id, includeRelated: false);

            if (ShoppingCart == null)
                return NotFound();

            repository.Remove(ShoppingCart);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }



        [HttpGet]
        public async Task<IActionResult> GetShoppingCart()
        {
            var ShoppingCarts = await repository.GetShoppingCart();

            if (ShoppingCarts == null)
                return NotFound();

            var ShoppingCartResources = mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartResources>>(ShoppingCarts);


            return Ok(ShoppingCartResources);
        }


    }
}