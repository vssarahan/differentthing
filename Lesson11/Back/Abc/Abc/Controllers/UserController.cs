using Abc.Data.Dto;
using Abc.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                return Ok(await _repo.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            try
            {
                UserDto user = await _repo.GetByIdAsync(id);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> Get(string email)
        {
            try
            {
                UserDto user = await _repo.GetByEmailAsync(email);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody]UserDto item)
        {
            try
            {
                UserDto user = await _repo.CreateAsync(item);
                if (user == null)
                    return BadRequest();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody]UserDto item)
        {
            try
            {
                return await _repo.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                return await _repo.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("email/{email}")]
        public async Task<ActionResult<bool>> Delete(string email)
        {
            try
            {
                return await _repo.DeleteByEmailAsync(email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
