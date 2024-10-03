using catedra1.Src.DTOs;
using catedra1.Src.Models;

namespace catedra1.Src.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Rut = userModel.Rut,
                Name = userModel.Name,
                Email = userModel.Email,
                Gender = userModel.Gender,
                Birthday = userModel.Birthday
            };
        }

        public static User ToUserModel(this UserDto userDto)
        {
            return new User
            {
                Rut = userDto.Rut,
                Name = userDto.Name,
                Email = userDto.Email,
                Gender = userDto.Gender,
                Birthday = userDto.Birthday
            };
        }

        public static GetUserDto ToGetUserDto(this User userModel)
        {
            return new GetUserDto
            {
                Id = userModel.Id,
                Rut = userModel.Rut,
                Name = userModel.Name,
                Email = userModel.Email,
                Gender = userModel.Gender,
                Birthday = userModel.Birthday.ToString("dd-MM-yyyy")
            };
        }

    }
}