namespace apiwc.entities;

public class User
{
    public string Id { get; set; }
    public string Names { get; set; }
    public string Email { get; set; }
    
    public string Token { get; set; }
    
    public string Password { get; set; }
    
    public int Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}


