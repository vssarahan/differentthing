using Abc.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abc.Data.Converters
{
    public static class UserConverter
    {
        public static UserDto Convert(User item)
        {
            return new UserDto
            {
                Name = item.Name,
                Surname = item.Surname,
                Email = item.Email,
                Id = item.Id
            };
        }

        public static User Convert(UserDto item)
        {
            return new User
            {
                Name = item.Name,
                Surname = item.Surname,
                Email = item.Email,
                Id = item.Id,
                UserName = item.Email
            };
        }

        public static List<UserDto> Convert(List<User> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }

        public static List<User> Convert(List<UserDto> items)
        {
            return items.Select(a => Convert(a)).ToList();
        }
    }
}
