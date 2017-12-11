using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToiLaHoi.Core;
using ToiLaHoi.Model;
using ToiLaHoi.Controllers.Resources;

namespace ToiLaHoi.Controllers.API
{
    [Route("/api/Category")]
    public class CategoryController : Controller
    {

        private readonly IMapper mapper;
        private readonly ICategoryRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IMapper mapper, ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        
      

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var category = await repository.GetCategory();
            if (category == null)
                return NotFound();
          var categoryResource =  mapper.Map<IEnumerable<Categories>, IEnumerable<CategoryResources>>(category);
          

            return Ok(categoryResource);
            
        }
    }
}