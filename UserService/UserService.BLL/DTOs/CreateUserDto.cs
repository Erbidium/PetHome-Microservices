namespace UserService.BLL.DTOs;

public class CreateUserDto
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}