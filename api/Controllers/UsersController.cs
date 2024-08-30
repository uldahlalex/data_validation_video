using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using service;


namespace api.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    [Route("/users")]
    public ActionResult CreateUser([FromBody]CreateUserDto dto)
    {
       
            return Ok(_service.CreateUser(dto));
   
    }
}

