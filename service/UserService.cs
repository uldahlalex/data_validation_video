using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace service;

public interface IUserService
{
    List<User> GetUsers();
    User CreateUser(CreateUserDto dto);
}

public class UserService : IUserService
{
    private readonly CreateUserDtoValidator _validator;

    public UserService(CreateUserDtoValidator validator)
    {
        _validator = validator;
        Console.WriteLine("service instantiated");
    }
    
    public List<User> GetUsers()
    {
        return new List<User>() { new User { Name = "User1" }, new User { Name = "User2" } };
    }

    public User CreateUser(CreateUserDto dto)
    {
        _validator.ValidateAndThrow(dto);
        return new User()
        {
            Name = dto.Name,
            Id = Math.Abs(dto.Name.GetHashCode())
        };
    }
}

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(user => user.Name.Length)
            .GreaterThanOrEqualTo(3);
    }
}

public class CreateUserDto
{
    public string Name { get; set; }
}

public class User
{
    public string Name { get; set; }
    public int Id { get; set; }
}