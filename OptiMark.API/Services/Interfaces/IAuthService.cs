using OptiMark.API.DTO;

namespace OptiMark.API.Services.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);
}