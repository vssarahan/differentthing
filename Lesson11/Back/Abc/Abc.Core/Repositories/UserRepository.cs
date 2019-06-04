using Abc.Data;
using Abc.Data.Converters;
using Abc.Data.Dto;
using Abc.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Abc.Core.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> um)
        {
            _userManager = um;
        }

        public  async Task<UserDto> CreateAsync(UserDto item)
        {
            User user = UserConverter.Convert(item);
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
                return null;
            var r = await _userManager.AddToRoleAsync(user, "user");
            if (!r.Succeeded)
                return null;
            return UserConverter.Convert(
                await _userManager.FindByEmailAsync(item.Email));
        }

        public  async Task<bool> DeleteByEmailAsync(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public  async Task<bool> DeleteByIdAsync(Guid id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return false;
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public  async Task<List<UserDto>> GetAllAsync()
        {
            return UserConverter.Convert
                (await _userManager.Users.ToListAsync());
        }

        public  async Task<UserDto> GetByEmailAsync(string email)
        {
            return UserConverter.Convert(
                await _userManager.FindByEmailAsync(email));
        }

        public  async Task<UserDto> GetByIdAsync(Guid id)
        {
            return UserConverter.Convert(
                await _userManager.FindByIdAsync(id.ToString()));
        }

        public  async Task<bool> UpdateAsync(UserDto item)
        {
            User user = UserConverter.Convert(item);
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
