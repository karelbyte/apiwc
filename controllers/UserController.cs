using apiwc.entities;
using apiwc.interfaces;
using apiwc.utils;
using Microsoft.AspNetCore.Mvc;

namespace apiwc.controllers;

[ApiController]
[Route("/api/users")]
public class UserController(IUserRepository userRepocitory) : ControllerBase
{
    
    private readonly IUserRepository _userRepository = userRepocitory;

    [HttpGet("/")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetAll();
    }

    [HttpGet("/{id}")]
    public async Task<object> GetUser(string id)
    {
        var user = await _userRepository.Detail(id);

        return user.Id != null ? user : new Message("Usuario no encontrado!", 422).Generate();
    }

    [HttpPut("/")]
    public async Task<object> UpdateUser(User user)
    {
        if (user.Id == null || (user.Email, user.Names) is ("", ""))
        {
             return new Message("User fields are required", 422).Generate();
        }
        var row = await _userRepository.Update(user);
        
        if (row == 1 && user.Id != null)
        {
            try
            {
                var userFound = await _userRepository.Detail(user.Id);
                return new
                {
                    id = userFound.Id,
                    names = userFound.Names,
                    email = userFound.Email,
                    status = userFound.Status,
                    createdAt = userFound.CreatedAt,
                    updatedAt = userFound.UpdatedAt
                };
            }
            catch (Exception e)
            {
                return new Message($"Internal error: {e.Message}" , 404).Generate();
            }  
      
        }
        else
        {
            return new Message("Not update user", 422).Generate();
        }
    }
    
    [HttpPost("/")]
    public async Task<object> CreateUser(User user)
    {
        if ((user.Email, user.Names) is ("", ""))
        {
            return new Message("User fields are required", 422).Generate();
        }
        try
        {
            var row = await _userRepository.Create(user);
            if (row == 1 && user.Id != null)
            {
                {
                    var userFound = await _userRepository.Detail(user.Id);
                    return new
                    {
                        id = userFound.Id,
                        names = userFound.Names,
                        email = userFound.Email,
                        status = userFound.Status,
                        createdAt = userFound.CreatedAt,
                        updatedAt = userFound.UpdatedAt
                    };
                }
            }
            else
            {
                return new Message("Not create user", 422).Generate();
            }
        }
        catch (Exception e)
        {
            return new Message($"Internal error: {e.Message}", 404).Generate();
        }


    }
}