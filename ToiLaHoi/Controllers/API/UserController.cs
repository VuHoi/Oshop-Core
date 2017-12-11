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

    [Route("/api/user")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserController(IMapper mapper, IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserID(int id)
        {
            var user = await repository.GetUserId(id);

            if (user == null)
                return NotFound();

            var userResource = mapper.Map<User,UserResources>(user);

            return Ok(userResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] SaveUserResources userResources)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = mapper.Map<SaveUserResources, User>(userResources);


            repository.Add(user);
            await unitOfWork.CompleteAsync();

            user = await repository.GetUserId(user.Id);

            var result = mapper.Map<User, UserResources>(user);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] SaveUserResources UserResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var User = await repository.GetUserId(id);

            if (User == null)
                return NotFound();

            mapper.Map<SaveUserResources, User>(UserResource, User);


            await unitOfWork.CompleteAsync();

            User = await repository.GetUserId(User.Id);
            var result = mapper.Map<User, SaveUserResources>(User);

            return Ok(result);
        }


    }
}