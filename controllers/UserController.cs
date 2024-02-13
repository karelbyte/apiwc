using apiwc.entities;
using apiwc.interfaces;
using apiwc.repositories;
using Microsoft.AspNetCore.Mvc;

namespace apiwc.controllers;

[ApiController]
[Route("/api/users")]
public class UserController: ControllerBase
{
    protected IUserRepository _userRepository;
    
    public UserController(IUserRepository userRepocitory)
    {
        _userRepository = userRepocitory;
    }
    
    [HttpGet("/")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetAll();
    }
    
}