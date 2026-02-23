using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


public class UsersController(IUserRepository userRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()
    {
        var users = await userRepository.GetUsersAsync();

        return Ok(users);
    }

     [HttpGet("{username}")] // /api/users/id
    public async Task<ActionResult<AppUser>>GetUsers(string username)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);

        if (user == null) return NotFound();

        return user;
    }
}